namespace ShipmentSystem.Domain.Common;

public interface IResult
{
    bool Success { get; }
    string Message { get; }
    List<string>? Errors { get; }
}
