using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status).HasConversion<string>().IsRequired();

        builder.Property(x => x.ShippedDate).IsRequired();

        builder.Property(x => x.EstimatedDeliveryDate).IsRequired(false);

        // Relationships
        builder
            .HasOne(x => x.Customer)
            .WithMany(c => c.Shipments)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.Driver).WithMany(d => d.Shipments).HasForeignKey(x => x.DriverId);

        builder.HasOne(x => x.Vehicle).WithMany(v => v.Shipments).HasForeignKey(x => x.VehicleId);

        // Owned Types - Origin & Destination
        builder.OwnsOne(
            x => x.Origin,
            a =>
            {
                a.Property(p => p.Street).HasColumnName("OriginStreet").IsRequired();
                a.Property(p => p.City).HasColumnName("OriginCity").IsRequired();
                a.Property(p => p.State).HasColumnName("OriginState").IsRequired();
                a.Property(p => p.PostalCode).HasColumnName("OriginPostalCode").IsRequired();
                a.Property(p => p.Country).HasColumnName("OriginCountry").IsRequired();
            }
        );

        builder.OwnsOne(
            x => x.Destination,
            a =>
            {
                a.Property(p => p.Street).HasColumnName("DestinationStreet").IsRequired();
                a.Property(p => p.City).HasColumnName("DestinationCity").IsRequired();
                a.Property(p => p.State).HasColumnName("DestinationState").IsRequired();
                a.Property(p => p.PostalCode).HasColumnName("DestinationPostalCode").IsRequired();
                a.Property(p => p.Country).HasColumnName("DestinationCountry").IsRequired();
            }
        );
    }
}
