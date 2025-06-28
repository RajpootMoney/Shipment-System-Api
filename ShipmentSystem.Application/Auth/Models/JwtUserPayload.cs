using ShipmentSystem.Domain.Enums;

namespace ShipmentSystem.Application.Auth.Models;

public class JwtUserPayload
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public UserRole Role { get; set; }
}
