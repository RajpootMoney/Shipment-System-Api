using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Weight).IsRequired().HasColumnType("decimal(10,2)");

        builder.Property(x => x.Dimensions).IsRequired().HasMaxLength(50);

        builder.Property(x => x.ContentDescription).IsRequired().HasMaxLength(200);

        builder.HasOne(x => x.Shipment).WithMany(s => s.Packages).HasForeignKey(x => x.ShipmentId);
    }
}
