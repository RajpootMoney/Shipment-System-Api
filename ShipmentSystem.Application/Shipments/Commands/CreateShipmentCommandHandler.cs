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
    private readonly IUnitOfWork _unitOfWork;

    public CreateShipmentHandler(IObjectMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.Shipments.AddAsync(shipment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(shipment.Id);
    }
}
