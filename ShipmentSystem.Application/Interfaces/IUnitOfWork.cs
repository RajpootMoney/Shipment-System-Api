using ShipmentSystem.Application.Interfaces.Common;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Shipment> Shipments { get; }
    IRepository<Package> Packages { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
