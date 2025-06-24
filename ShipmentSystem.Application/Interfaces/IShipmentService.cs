using ShipmentSystem.Application.DTOs;

namespace ShipmentSystem.Application.Interfaces;

public interface IShipmentService
{
    Task<Guid> CreateShipmentAsync(CreateShipmentDto dto);
}
