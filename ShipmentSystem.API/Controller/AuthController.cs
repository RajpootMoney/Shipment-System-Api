using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShipmentSystem.Application.Auth.Commands;
using ShipmentSystem.Domain.Common;

namespace ShipmentSystem.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(Result<string>.Ok(result.Data, "Login successful"));
    }

    [HttpPost("register/customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(Result<string>.Ok(result.Data, "Customer registered successfully"));
    }

    [HttpPost("register/driver")]
    public async Task<IActionResult> RegisterDriver([FromBody] RegisterDriverCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(Result<string>.Ok(result.Data, "Driver registered successfully"));
    }
}
