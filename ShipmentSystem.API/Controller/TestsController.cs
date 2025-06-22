using Microsoft.AspNetCore.Mvc;

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
}
