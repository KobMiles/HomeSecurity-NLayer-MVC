using HomeSecurity.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Configurations;

public class SensorAlertConfiguration : IEntityTypeConfiguration<SensorAlert>
{
    public void Configure(EntityTypeBuilder<SensorAlert> builder)
    {
        builder.HasKey(sa => sa.Id);

        builder.Property(sa => sa.Timestamp)
            .IsRequired();

        builder.Property(sa => sa.Message)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.HasOne(sa => sa.Sensor)
            .WithMany(s => s.Alerts)
            .HasForeignKey(sa => sa.SensorId);
    }
}