namespace HomeSecurity.BLL.DTOs.SensorAlerts;

public class SensorAlertDto
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Message { get; set; }
    public int SensorId { get; set; }
    public string SensorName { get; set; } = string.Empty;
    public string SensorType { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
}