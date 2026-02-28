using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Clients.Command.Request;
using TriVibe.Application.CQRS.Clients.Query.Request;

namespace TriVibeWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddClientCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClientCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteClientCommandRequest { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllClientsQueryRequest());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetClientByIdQueryRequest { Id = id });
        return Ok(response);
    }
}
