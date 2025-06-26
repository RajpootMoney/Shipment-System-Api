using MediatR;
using ShipmentSystem.Application.Constants;
using ShipmentSystem.Application.Exceptions;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Domain.Entities;
using ShipmentSystem.Domain.Enums;
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
        var dto = request.Dto;

        var origin = _mapper.Map<Address>(dto.Origin);
        var destination = _mapper.Map<Address>(dto.Destination);

        if (origin == destination)
            throw new DomainValidationException(ErrorMessages.Shipment.OriginAndDestinationSame);

        var shipment = new Shipment(
            customerId: dto.CustomerId,
            driverId: dto.DriverId,
            vehicleId: dto.VehicleId,
            origin: origin,
            destination: destination,
            shippedDate: dto.ShippedDate,
            status: Enum.Parse<ShipmentStatus>(dto.Status, ignoreCase: true),
            estimatedDeliveryDate: dto.EstimatedDeliveryDate
        );

        // Map and add packages if any
        if (dto.Packages != null && dto.Packages.Any())
        {
            foreach (var packageDto in dto.Packages)
            {
                var package = new Package(
                    shipmentId: shipment.Id,
                    weight: packageDto.Weight,
                    dimensions: packageDto.Dimensions,
                    contentDescription: packageDto.ContentDescription
                );
                shipment.Packages.Add(package);
            }
        }

        await _unitOfWork.Shipments.AddAsync(shipment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return shipment.Id;
    }
}
