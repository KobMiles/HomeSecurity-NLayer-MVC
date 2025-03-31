namespace HomeSecurity.BLL.DTOs.SensorAlerts;

public class SensorAlertDto
{
    public int Id { get; set; }
    public int SensorId { get; set; }
    public DateTime Timestamp { get; set; }
    public string? Message { get; set; }
}