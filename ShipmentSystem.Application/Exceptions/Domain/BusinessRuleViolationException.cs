namespace ShipmentSystem.Application.Exceptions.Domain;

public class BusinessRuleViolationException : DomainException
{
    public BusinessRuleViolationException(string message)
        : base(message) { }
}
