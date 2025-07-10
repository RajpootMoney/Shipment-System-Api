using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShipmentSystem.Application.DTOs.Shipments;
using ShipmentSystem.Application.Shipments.Commands;
using ShipmentSystem.Application.Shipments.Queries;
using ShipmentSystem.Infrastructure.BackgroundJobs.Interfaces;

namespace ShipmentSystem.API.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ShipmentsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IBackgroundJobClient _backgroundJob;

    public ShipmentsController(IMediator mediator, IBackgroundJobClient backgroundJob)
    {
        _mediator = mediator;
        _backgroundJob = backgroundJob;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShipmentDto dto)
    {
        var id = await _mediator.Send(new CreateShipmentCommand(dto));

        _backgroundJob.Enqueue<IShipmentJobService>(job => job.ProcessShipmentAsync(id));

        return CreatedAtAction(nameof(GetById), new { id }, new { shipmentId = id });
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetShipmentByIdQuery(id));
        return Ok(result);
    }
}
