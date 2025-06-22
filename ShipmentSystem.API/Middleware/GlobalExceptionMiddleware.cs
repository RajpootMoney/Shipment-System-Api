using System.Net;
using System.Text.Json;
using ShipmentSystem.Application.Exceptions;

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
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "💥 Exception caught in GlobalExceptionMiddleware");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;
        string message;

        switch (exception)
        {
            case NotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                message = exception.Message;
                break;

            case ValidationException:
                statusCode = (int)HttpStatusCode.BadRequest;
                message = exception.Message;
                break;

            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                message = "Internal Server Error";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var result = JsonSerializer.Serialize(new { StatusCode = statusCode, Message = message });

        return context.Response.WriteAsync(result);
    }
}
