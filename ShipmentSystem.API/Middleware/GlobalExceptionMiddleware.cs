using System.Net;
using System.Text.Json;
using ShipmentSystem.Application.Exceptions;
using ShipmentSystem.Application.Exceptions.Application;
using ShipmentSystem.Domain.Common;

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
            _logger.LogError(
                ex,
                "//==========================Exception caught in GlobalExceptionMiddleware=====================//"
            );
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode = (int)HttpStatusCode.InternalServerError;
        string message = "Internal Server Error";
        List<string>? errors = null;

        switch (exception)
        {
            case NotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                message = exception.Message;
                break;

            case ValidationException validationEx:
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Validation failed";
                errors = validationEx.Errors?.ToList();
                break;

            case DomainValidationException domainValidationEx:
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Validation failed";
                errors = domainValidationEx.Errors?.ToList(); // You updated this already
                break;

            default:
                message = exception.Message; // Optionally hide this in prod
                break;
        }

        var response = Result<string>.Fail(message, errors);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
