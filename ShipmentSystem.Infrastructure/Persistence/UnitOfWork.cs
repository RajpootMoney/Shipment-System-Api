using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Application.Interfaces.Common;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Infrastructure.Persistence.Common;

namespace ShipmentSystem.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShipmentDbContext _context;

    public UnitOfWork(ShipmentDbContext context)
    {
        _context = context;
        Shipments = new Repository<Shipment>(_context);
    }

    public IRepository<Shipment> Shipments { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();
}
