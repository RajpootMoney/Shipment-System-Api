using MediatR;
using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Application.Auth.Commands;

public class LoginCommand : IRequest<Result<string>>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
