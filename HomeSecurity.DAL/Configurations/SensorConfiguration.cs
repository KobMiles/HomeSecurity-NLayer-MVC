using HomeSecurity.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSecurity.DAL.Configurations;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.
            Property(s => s.SensorType)
            .IsRequired();

        builder
            .Property(s => s.LocationId)
            .IsRequired();

        builder
            .Property(s => s.LastReading)
            .IsRequired(false);

        builder
            .Property(s => s.DataLabel)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(s => s.Data)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(s => s.IsAlert)
            .IsRequired(false);

        builder
            .HasOne(s => s.Location)
            .WithMany(l => l.Sensors)
            .HasForeignKey(s => s.LocationId);

        builder
            .HasMany(s => s.Alerts)
            .WithOne(a => a.Sensor)
            .HasForeignKey(a => a.SensorId);
    }
}