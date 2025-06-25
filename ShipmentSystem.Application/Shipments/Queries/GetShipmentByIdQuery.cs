using MediatR;
using ShipmentSystem.Application.DTOs;

namespace ShipmentSystem.Application.Shipments.Queries;

public record GetShipmentByIdQuery(Guid Id) : IRequest<ShipmentDto>;
