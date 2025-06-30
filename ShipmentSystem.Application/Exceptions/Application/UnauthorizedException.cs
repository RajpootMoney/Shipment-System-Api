namespace ShipmentSystem.Application.Exceptions.Application;

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message)
        : base(message) { }
}
