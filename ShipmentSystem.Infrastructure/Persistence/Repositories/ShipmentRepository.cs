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
        return _dbSet.FirstOrDefaultAsync(s => s.Id == id);
    }
}
