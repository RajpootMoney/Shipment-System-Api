using System.Text.Json;

namespace ShipmentSystem.API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger
    )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // proceed to next middleware
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Exception caught in middleware: {ex.Message}");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(
            new
            {
                StatusCode = 500,
                Message = "Internal Server Error",
                Details = exception.Message
            }
        );

        return context.Response.WriteAsync(result);
    }
}
