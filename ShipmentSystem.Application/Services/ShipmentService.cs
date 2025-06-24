using ShipmentSystem.Application.Constants;
using ShipmentSystem.Application.DTOs;
using ShipmentSystem.Application.Exceptions;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Application.Services;

public class ShipmentService : IShipmentService
{
    private readonly IObjectMapper _mapper;

    public ShipmentService(IObjectMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<Guid> CreateShipmentAsync(CreateShipmentDto dto)
    {
        var origin = _mapper.Map<Address>(dto.Origin);
        var destination = _mapper.Map<Address>(dto.Destination);

        if (origin == destination)
            throw new DomainValidationException(ErrorMessages.Shipment.OriginAndDestinationSame);

        var shipment = new Shipment(origin, destination, dto.ShippedDate);

        return await Task.FromResult(shipment.Id);
    }
}
