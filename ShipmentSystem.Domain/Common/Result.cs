namespace ShipmentSystem.Domain.Common;

public class Result<T> : IResult
{
    public bool Success { get; init; }
    public T Data { get; init; }
    public string Message { get; init; }
    public List<string> Errors { get; init; }

    public static Result<T> Ok(T data, string message = "") =>
        new()
        {
            Success = true,
            Data = data,
            Message = message
        };

    public static Result<T> Fail(string message, List<string>? errors = null) =>
        new()
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>()
        };
}
