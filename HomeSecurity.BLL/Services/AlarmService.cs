using AutoMapper;
using HomeSecurity.BLL.DTOs.SensorAlerts;
using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity.DAL.Entities.Enums;
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
                alerts = alerts.OrderBy(a => a.Timestamp).ToList();
                break;
            case "date_desc":
                alerts = alerts.OrderByDescending(a => a.Timestamp).ToList();
                break;
            case "sensorType":
                alerts = alerts.OrderBy(a => a.Sensor.SensorType).ToList();
                break;
            case "room":
                alerts = alerts.OrderBy(a => a.Sensor.Location.Name).ToList();
                break;
            default:
                break;
        }

        return mapper.Map<IEnumerable<SensorAlertDto>>(alerts);
    }
}