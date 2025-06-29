namespace ShipmentSystem.Domain.Common;

public class PagedResult<T> : Result<IEnumerable<T>>
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }

    public static PagedResult<T> Ok(
        IEnumerable<T> data,
        int page,
        int pageSize,
        int totalCount,
        string message = ""
    ) =>
        new()
        {
            Success = true,
            Data = data,
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            Message = message
        };
}
