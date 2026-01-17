using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Users.Command.Request;
namespace TriVibeWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegistrationUserCommandRequest request)
    {
        return Ok(await Sender.Send(request));
    }
}
