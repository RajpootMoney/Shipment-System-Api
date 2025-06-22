using Microsoft.AspNetCore.Mvc;
using ShipmentSystem.Application.Exceptions;

namespace ShipmentSystem.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly ILogger<TestsController> _logger;

    public TestsController(ILogger<TestsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("crash")]
    public IActionResult CrashApp()
    {
        _logger.LogInformation("⚠️ About to crash intentionally...");

        // This will trigger the middleware
        throw new Exception("💥 This is a test exception to verify middleware logging!");
    }

    [HttpGet("notfound")]
    public IActionResult ThrowNotFound()
    {
        throw new NotFoundException("Shipment not found with given ID.");
    }

    [HttpGet("invalid")]
    public IActionResult ThrowValidation()
    {
        throw new ValidationException("Provided shipment data is invalid.");
    }
}
