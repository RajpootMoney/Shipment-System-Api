namespace ShipmentSystem.Application.Auth.Commands;

public class RegisterCustomerCommand : RegisterCommand
{
    public string CompanyName { get; init; }
}
