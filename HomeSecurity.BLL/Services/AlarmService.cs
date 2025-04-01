using AutoMapper;
using HomeSecurity.BLL.DTOs.SensorAlerts;
using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity.DAL.Entities;
using HomeSecurity.DAL.Entities.Specifications.SensorAlerts;
using HomeSecurity.DAL.Interfaces.Repositories;

namespace HomeSecurity.BLL.Services;

public class AlarmService(IUnitOfWork unitOfWork, IMapper mapper) : IAlarmService
{
    public async Task<IEnumerable<SensorAlertDto>> GetSensorAlertsAsync(string sortOrder = "date_desc")
    {
        var spec = new SensorAlertsWithSensorSpec();
        var alerts = await unitOfWork.SensorAlerts.ListAsync(spec);

        switch (sortOrder)
        {
            case "date_asc":
                alerts = [.. alerts.OrderBy(a => a.Timestamp)];
                break;
            case "date_desc":
                alerts = [.. alerts.OrderByDescending(a => a.Timestamp)];
                break;
            case "sensorType":
                alerts = [.. alerts.OrderBy(a => a.Sensor.SensorType)];
                break;
            case "room":
                alerts = [.. alerts.OrderBy(a => a.Sensor.Location.Name)];
                break;
        }

        return mapper.Map<IEnumerable<SensorAlertDto>>(alerts);
    }

    public async Task<bool> GetAlarmStatusAsync()
    {
        var status = await unitOfWork.AlarmStatuses.GetByIdAsync(1);
        return status?.IsActive ?? true;
    }

    public async Task ToggleAlarmStatusAsync()
    {
        var status = await unitOfWork.AlarmStatuses.GetByIdAsync(1);
        if (status == null)
        {
            status = new AlarmStatus { IsActive = true };
            await unitOfWork.AlarmStatuses.AddAsync(status);
        }
        else
        {
            status.IsActive = !status.IsActive;
            status.LastUpdated = DateTime.Now;
            await unitOfWork.AlarmStatuses.UpdateAsync(status);
        }
        await unitOfWork.SaveAsync();
    }
}