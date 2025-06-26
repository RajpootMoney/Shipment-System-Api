using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
        builder.Property(x => x.LicenseNumber).IsRequired().HasMaxLength(50);

        builder.HasIndex(x => x.LicenseNumber).IsUnique();
    }
}
