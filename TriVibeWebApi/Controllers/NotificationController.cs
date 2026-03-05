using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Notifications.Command.Request;
using TriVibe.Application.CQRS.Notifications.Query.Request;

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

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddNotificationCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateNotificationCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteNotificationCommandRequest { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllNotificationsQueryRequest());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetNotificationByIdQueryRequest { Id = id });
        return Ok(response);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var response = await _mediator.Send(new GetNotificationsByUserIdQueryRequest { UserId = userId });
        return Ok(response);
    }
    [HttpGet("{workerId}")]
    public async Task<IActionResult> Worker(Guid workerId)
    {
        var response = await _mediator.Send(new TriVibe.Application.CQRS.Orders.Query.Request.GetWorkerNotificationsQueryRequest { WorkerId = workerId });
        return Ok(response);
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> Client(Guid clientId)
    {
        var response = await _mediator.Send(new TriVibe.Application.CQRS.Orders.Query.Request.GetClientNotificationsQueryRequest { ClientId = clientId });
        return Ok(response);
    }
}

