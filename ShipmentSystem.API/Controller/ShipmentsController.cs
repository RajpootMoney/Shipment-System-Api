using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShipmentSystem.Application.DTOs;
using ShipmentSystem.Application.Shipments.Commands;
using ShipmentSystem.Application.Shipments.Queries;

namespace ShipmentSystem.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShipmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShipmentDto dto)
    {
        var id = await _mediator.Send(new CreateShipmentCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id }, new { shipmentId = id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetShipmentByIdQuery(id));
        return Ok(result);
    }
}
