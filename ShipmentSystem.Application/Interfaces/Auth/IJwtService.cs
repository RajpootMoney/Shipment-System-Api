using ShipmentSystem.Application.Auth.Models;

namespace ShipmentSystem.Application.Interfaces.Auth;

public interface IJwtService
{
    string GenerateToken(JwtUserPayload jwtUserPayload);
}
