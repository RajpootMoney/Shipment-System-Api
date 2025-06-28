using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Only Customer-specific configuration
        builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(150);

        builder.Property(x => x.Type).HasConversion<string>().IsRequired();

        // Relationship with Shipments (optional)
        builder
            .HasMany(c => c.Shipments)
            .WithOne(s => s.Customer)
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
