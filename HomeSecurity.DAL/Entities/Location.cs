using HomeSecurity.DAL.Interfaces;

namespace HomeSecurity.DAL.Entities;

public class Location : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
}