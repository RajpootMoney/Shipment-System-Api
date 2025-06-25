using Microsoft.EntityFrameworkCore;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Infrastructure.Persistence.Repositories;

public class ShipmentRepository : IShipmentRepository
{
    private readonly ShipmentDbContext _context;

    public ShipmentRepository(ShipmentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Shipment shipment, CancellationToken cancellationToken)
    {
        await _context.Shipments.AddAsync(shipment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Shipment?> GetByIdAsync(Guid id)
    {
        return await _context.Shipments.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
    }
}
