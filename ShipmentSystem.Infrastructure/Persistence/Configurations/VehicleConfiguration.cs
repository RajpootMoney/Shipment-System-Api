using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.VehicleNumber).IsRequired().HasMaxLength(50);

        builder.HasIndex(x => x.VehicleNumber).IsUnique();

        builder.OwnsOne(
            x => x.VehicleType,
            tt =>
            {
                tt.Property(t => t.Value)
                    .HasColumnName("VehicleType")
                    .IsRequired()
                    .HasMaxLength(50);
            }
        );

        builder.Property(x => x.Capacity).IsRequired().HasColumnType("decimal(10,2)");
    }
}
