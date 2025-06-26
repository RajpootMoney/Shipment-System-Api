using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class TrackingEventConfiguration : IEntityTypeConfiguration<TrackingEvent>
{
    public void Configure(EntityTypeBuilder<TrackingEvent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Event).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Timestamp).IsRequired();

        builder.Property(x => x.Location).IsRequired().HasMaxLength(100);

        builder
            .HasOne(x => x.Shipment)
            .WithMany(s => s.TrackingEvents)
            .HasForeignKey(x => x.ShipmentId);
    }
}
