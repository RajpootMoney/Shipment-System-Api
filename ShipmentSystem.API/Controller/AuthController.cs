using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShipmentSystem.Application.Auth.Commands;

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
        var token = await _mediator.Send(command);
        return Ok(new { token });
    }

    [HttpPost("register/customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(new { token });
    }

    [HttpPost("register/driver")]
    public async Task<IActionResult> RegisterDriver([FromBody] RegisterDriverCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(new { token });
    }
}
