using HomeSecurity.BLL.DTOs.SensorAlerts;

namespace HomeSecurity.BLL.Interfaces.Services;

public interface IAlarmService
{
    Task<IEnumerable<SensorAlertDto>> GetSensorAlertsAsync(string sortOrder = "date_desc");
}