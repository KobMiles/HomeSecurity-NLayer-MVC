using HomeSecurity.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HomeSecurity.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100); 

        builder
            .Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .ToTable("Users");
    }
}