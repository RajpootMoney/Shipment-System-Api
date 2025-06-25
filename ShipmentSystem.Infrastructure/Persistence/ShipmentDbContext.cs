using Microsoft.EntityFrameworkCore;
using ShipmentSystem.Domain.Common;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence
{
    public class ShipmentDbContext : DbContext
    {
        public ShipmentDbContext(DbContextOptions<ShipmentDbContext> options)
            : base(options) { }

        public DbSet<Shipment> Shipments => Set<Shipment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShipmentDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity<Guid>>())
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
