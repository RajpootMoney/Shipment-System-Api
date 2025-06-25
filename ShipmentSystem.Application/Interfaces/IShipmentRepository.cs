using ShipmentSystem.Application.Interfaces.Common;
using ShipmentSystem.Domain.Entities;

namespace ShipmentSystem.Application.Interfaces;

public interface IShipmentRepository : IRepository<Shipment>
{
    Task<Shipment?> GetShipmentWithDetails(Guid id);
}
