using MediatR;
using ShipmentSystem.Application.Interfaces.Auth;
using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Application.Auth.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IAuth0Service _auth0Service;

    public LoginCommandHandler(IAuth0Service auth0Service)
    {
        _auth0Service = auth0Service;
    }

    public async Task<Result<string>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken
    )
    {
        var tokenResult = await _auth0Service.LoginAsync(
            request.Email,
            request.Password,
            cancellationToken
        );

        if (!tokenResult.IsSuccess)
            return Result<string>.Fail(tokenResult.ErrorMessage);

        return Result<string>.Ok(tokenResult.AccessToken!, "Login success!");
    }
}
