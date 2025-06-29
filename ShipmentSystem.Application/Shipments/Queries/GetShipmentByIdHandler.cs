using MediatR;
using ShipmentSystem.Application.Constants;
using ShipmentSystem.Application.DTOs;
using ShipmentSystem.Application.DTOs.Shipments;
using ShipmentSystem.Application.Exceptions;
using ShipmentSystem.Application.Interfaces;

namespace ShipmentSystem.Application.Shipments.Queries;

public class GetShipmentByIdHandler : IRequestHandler<GetShipmentByIdQuery, ShipmentDto>
{
    private readonly IShipmentRepository _repository;
    private readonly IObjectMapper _mapper;

    public GetShipmentByIdHandler(IShipmentRepository repository, IObjectMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ShipmentDto> Handle(
        GetShipmentByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var shipment = await _repository.GetShipmentWithDetails(request.Id);

        if (shipment == null)
            throw new NotFoundException(ErrorMessages.Shipment.NotFound);

        return _mapper.Map<ShipmentDto>(shipment);
    }
}
