using System.Net;

namespace ShipmentSystem.Application.Exceptions;

public class ConflictException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;

    public ConflictException()
        : base("A conflict occurred.") { }

    public ConflictException(string message)
        : base(message) { }

    public ConflictException(string message, Exception innerException)
        : base(message, innerException) { }
}
