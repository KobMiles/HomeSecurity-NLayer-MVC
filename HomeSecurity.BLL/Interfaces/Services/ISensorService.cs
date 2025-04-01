using HomeSecurity.BLL.DTOs.SensorAlerts;
using HomeSecurity.BLL.DTOs.Sensors;

namespace HomeSecurity.BLL.Interfaces.Services;

public interface ISensorService
{
    Task<IEnumerable<SensorDto>> GetAllSensorsAsync();
    Task<IEnumerable<SensorDto>> UpdateSensorsRandomlyAsync();
    Task CreateSensorAlertAsync(SensorAlertCreateDto sensorAlertDto);
}