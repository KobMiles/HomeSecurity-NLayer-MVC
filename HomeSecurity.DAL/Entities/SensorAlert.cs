using HomeSecurity.DAL.Interfaces;

namespace HomeSecurity.DAL.Entities;

public class SensorAlert : IEntity
{
    public int Id { get; set; }
    public int SensorId { get; set; }
    public Sensor Sensor { get; set; } = null!;
    public DateTime Timestamp { get; set; }

    public string? Message { get; set; }
}
