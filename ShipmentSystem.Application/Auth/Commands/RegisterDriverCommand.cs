namespace ShipmentSystem.Application.Auth.Commands;

public class RegisterDriverCommand : RegisterCommand
{
    public string LicenseNumber { get; init; }
}
