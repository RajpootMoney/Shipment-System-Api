using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        // Configure Driver-specific fields only
        builder.Property(x => x.LicenseNumber).IsRequired().HasMaxLength(50);

        builder.HasIndex(x => x.LicenseNumber).IsUnique();

        // Configure navigation
        builder
            .HasMany(d => d.Shipments)
            .WithOne(s => s.Driver)
            .HasForeignKey(s => s.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
