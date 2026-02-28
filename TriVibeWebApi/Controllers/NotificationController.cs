using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Orders.Command.Request;
using TriVibe.Application.CQRS.Orders.Query.Request;

namespace TriVibeWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{workerId}")]
    public async Task<IActionResult> Worker(Guid workerId)
    {
        var request = new GetWorkerNotificationsQueryRequest { WorkerId = workerId };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> MarkAsRead(Guid id)
    {
        var request = new MarkNotificationAsReadCommandRequest { NotificationId = id };
        var response = await _mediator.Send(request);
        if (!response.Data.Success) return BadRequest(response);
        return Ok(response);
    }
}
