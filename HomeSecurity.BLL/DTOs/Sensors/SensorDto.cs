using HomeSecurity.DAL.Entities.Enums;

namespace HomeSecurity.BLL.DTOs.Sensors;

public class SensorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string DataLabel { get; set; } = null!;
    public string Data { get; set; } = null!;
    public bool? IsAlert { get; set; }
    public double? LastReading { get; set; }
    public string LocationName { get; set; } = null!;
    public SensorType SensorType { get; set; }
    public string SensorTypeName => SensorType.ToString();
}