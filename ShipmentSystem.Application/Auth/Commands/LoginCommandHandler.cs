using MediatR;
using ShipmentSystem.Application.Auth.Models;
using ShipmentSystem.Application.Exceptions.Application;
using ShipmentSystem.Application.Interfaces;
using ShipmentSystem.Application.Interfaces.Auth;
using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.Application.Auth.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IObjectMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(IUnitOfWork unitOfWork, IJwtService jwtService, IObjectMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }

    public async Task<Result<string>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.Users.FindByEmailAsync(request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedException("Invalid email or password.");
        }

        var jwtPayload = _mapper.Map<JwtUserPayload>(user);

        return Result<string>.Ok(_jwtService.GenerateToken(jwtPayload), "Login success!");
    }
}
