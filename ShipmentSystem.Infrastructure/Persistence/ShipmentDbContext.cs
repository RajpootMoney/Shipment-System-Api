using Microsoft.EntityFrameworkCore;
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
    }
}
