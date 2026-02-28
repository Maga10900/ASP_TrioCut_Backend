using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Workers.Command.Request;
using TriVibe.Application.CQRS.Workers.Query.Request;

namespace TriVibeWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddWorkerCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateWorkerCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new DeleteWorkerCommandRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllWorkerQueryRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var request = new GetWorkerByIdQueryRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
