using Microsoft.EntityFrameworkCore;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Infrastructure.Persistence.Common;

namespace ShipmentSystem.Infrastructure.Persistence.Repositories;

public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
{
    public ShipmentRepository(ShipmentDbContext context)
        : base(context) { }

    public Task<Shipment?> GetShipmentWithDetails(Guid id)
    {
        return _dbSet
            .Include(x => x.Customer)
            .Include(x => x.Driver)
            .Include(x => x.Vehicle)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
