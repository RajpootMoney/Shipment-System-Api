using MediatR;
using ShipmentSystem.Application.DTOs;

namespace ShipmentSystem.Application.Shipments.Commands;

public record CreateShipmentCommand(CreateShipmentDto Dto) : IRequest<Guid>;
