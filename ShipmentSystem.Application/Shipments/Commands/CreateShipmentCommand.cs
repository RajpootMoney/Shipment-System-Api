using MediatR;
using ShipmentSystem.Application.DTOs.Shipments;

namespace ShipmentSystem.Application.Shipments.Commands;

public record CreateShipmentCommand(CreateShipmentDto Dto) : IRequest<Guid>;
