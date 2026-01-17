using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibe.Application.CQRS.Barbers.Query.Request;
using TriVibeWebApi.Constants;

namespace TriVibeWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = $"{UserRoles.Admin}")]
public class BarberController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddBarber(AddBarberCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBarber(Guid id)
    {
        return Ok(await Sender.Send(new DeleteBarberCommandRequest() { Id = id }));
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllBarbers([FromQuery] GetAllBarbersQueryRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [HttpGet]
    [Authorize(Roles = $"{UserRoles.Admin}, {UserRoles.Barber}")]
    public async Task<IActionResult> GetAllBarberAppointments([FromQuery] GetAllBarbersQueryRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [HttpPut]
    [Authorize(Roles = $"{UserRoles.Admin}, {UserRoles.Barber}")]

    [AllowAnonymous]
    public async Task<IActionResult> UpdateBarber(UpdateBarberCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBarberById(Guid id)
    {
        var query = new GetByIdBarberQueryRequest { Id = id };
        return Ok(await Sender.Send(query));
    }
}
