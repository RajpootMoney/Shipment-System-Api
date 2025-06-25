using MediatR;
using ShipmentSystem.Application.Constants;
using ShipmentSystem.Application.Exceptions;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Domain.ValueObjects;

namespace ShipmentSystem.Application.Shipments.Commands;

public class CreateShipmentHandler : IRequestHandler<CreateShipmentCommand, Guid>
{
    private readonly IObjectMapper _mapper;

    public CreateShipmentHandler(IObjectMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<Guid> Handle(
        CreateShipmentCommand request,
        CancellationToken cancellationToken
    )
    {
        var origin = _mapper.Map<Address>(request.Dto.Origin);
        var destination = _mapper.Map<Address>(request.Dto.Destination);

        if (origin == destination)
            throw new DomainValidationException(ErrorMessages.Shipment.OriginAndDestinationSame);

        var shipment = new Shipment(origin, destination, request.Dto.ShippedDate);

        // TODO: Save to DB once infra ready

        return await Task.FromResult(shipment.Id);
    }
}
