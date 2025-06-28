using MediatR;
using ShipmentSystem.Application.DTOs.Shipments;

namespace ShipmentSystem.Application.Shipments.Queries;

public record GetShipmentByIdQuery(Guid Id) : IRequest<ShipmentDto>;
