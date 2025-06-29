namespace ShipmentSystem.Application.Exceptions;

public class DomainValidationException : Exception
{
    public IReadOnlyCollection<string> Errors { get; }

    public DomainValidationException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public DomainValidationException(IEnumerable<string> errors)
        : base("One or more validation failures have occurred.")
    {
        Errors = errors.ToList().AsReadOnly();
    }
}
