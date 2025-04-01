using HomeSecurity.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .HasKey(l => l.Id);

        builder
            .Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasMany(l => l.Sensors)
            .WithOne(s => s.Location)
            .HasForeignKey(s => s.LocationId);
    }
}