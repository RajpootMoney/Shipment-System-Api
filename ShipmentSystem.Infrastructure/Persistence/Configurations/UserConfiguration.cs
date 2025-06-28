using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Primary key
        builder.HasKey(x => x.Id);

        // Common fields
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);

        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(200);

        builder.Property(x => x.Role).IsRequired().HasConversion<string>(); // Optional: store role as string

        // Discriminator for TPH (Table-per-Hierarchy)
        builder
            .HasDiscriminator<UserRole>("Role")
            .HasValue<Driver>(UserRole.Driver)
            .HasValue<Customer>(UserRole.Customer);

        // Optional: Single table for all user types
        builder.ToTable("Users");
    }
}
