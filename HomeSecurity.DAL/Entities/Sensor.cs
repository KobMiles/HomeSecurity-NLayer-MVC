using HomeSecurity.DAL.Entities.Enums;
using HomeSecurity.DAL.Interfaces;

namespace HomeSecurity.DAL.Entities;

public class Sensor : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public SensorType SensorType { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public double? LastReading { get; set; }
    public string DataLabel { get; set; } = null!;
    public string Data { get; set; } = null!;
    public bool? IsAlert { get; set; }

    public ICollection<SensorAlert> Alerts { get; set; } = new HashSet<SensorAlert>();
}