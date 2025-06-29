using MediatR;
using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Application.Auth.Commands;

public abstract class RegisterCommand : IRequest<Result<string>>
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Password { get; init; }
}
