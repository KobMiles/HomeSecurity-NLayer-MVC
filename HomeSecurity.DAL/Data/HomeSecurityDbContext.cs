using HomeSecurity.DAL.Configurations;
using HomeSecurity.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Data;

public class HomeSecurityDbContext(DbContextOptions<HomeSecurityDbContext> options)
    : IdentityDbContext<User>(options)

{
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SensorAlert> SensorsAlerts { get; set; }
    public DbSet<AlarmStatus> AlarmStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new SensorConfiguration());
        modelBuilder.ApplyConfiguration(new SensorAlertConfiguration());
        modelBuilder.ApplyConfiguration(new AlarmStatusConfiguration());

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.SeedAlarmStatus();
        modelBuilder.SeedLocations();
        modelBuilder.SeedSensors();
    }
}