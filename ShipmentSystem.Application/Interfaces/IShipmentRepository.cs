using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Application.Interfaces;

public interface IShipmentRepository
{
    Task AddAsync(Shipment shipment, CancellationToken cancellationToken);
    Task<Shipment?> GetByIdAsync(Guid id);
}
