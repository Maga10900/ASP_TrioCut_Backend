using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Orders.Command.Request;
using TriVibe.Application.CQRS.Orders.Query.Request;

namespace TriVibeWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddOrderCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new DeleteOrderCommandRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Accept(Guid id)
    {
        var request = new UpdateOrderStatusCommandRequest { OrderId = id, Status = TriVibe.Domain.Enums.OrderStatus.Accepted };
        var response = await _mediator.Send(request);
        if(!response.Data.Success) return BadRequest(response);
        return Ok(response);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Reject(Guid id)
    {
        var request = new UpdateOrderStatusCommandRequest { OrderId = id, Status = TriVibe.Domain.Enums.OrderStatus.Rejected };
        var response = await _mediator.Send(request);
        if(!response.Data.Success) return BadRequest(response);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllOrderQueryRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var request = new GetOrderByIdQueryRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
