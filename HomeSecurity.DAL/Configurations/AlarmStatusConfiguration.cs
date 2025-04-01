using HomeSecurity.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Configurations;

public class AlarmStatusConfiguration : IEntityTypeConfiguration<AlarmStatus>
{
    public void Configure(EntityTypeBuilder<AlarmStatus> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.IsActive)
            .IsRequired();

        builder
            .Property(a => a.LastUpdated)
            .IsRequired();
    }
}