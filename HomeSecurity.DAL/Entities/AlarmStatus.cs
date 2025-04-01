using HomeSecurity.DAL.Interfaces;

namespace HomeSecurity.DAL.Entities;

public class AlarmStatus : IEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}