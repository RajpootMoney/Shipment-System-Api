using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TruckNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.TruckType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Capacity).IsRequired().HasColumnType("decimal(10,2)");

        builder.HasIndex(x => x.TruckNumber).IsUnique();
    }
}
