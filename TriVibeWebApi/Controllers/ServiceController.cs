using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Services.Command.Requset;
using TriVibe.Application.CQRS.Services.Query.Request;
using TriVibeWebApi.Constants;

namespace TriVibeWebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
    [Authorize(Roles = $"{UserRoles.Admin}")]
    public class ServiceController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> AddService(AddServiceCommandRequest request)
		{
			return Ok(await Sender.Send(request));
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteService(Guid id)
		{
			return Ok(await Sender.Send(new DeleteServiceCommandRequest() { Id = id }));
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetAllServices([FromQuery] GetAllServicesQueryRequest request)
		{
			return Ok(await Sender.Send(request));
		}
		[HttpPut]
		public async Task<IActionResult> UpdateService(UpdateServiceCommandRequest request)
		{
			return Ok(await Sender.Send(request));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetServiceById(Guid id)
		{
			var query = new GetByIdServiceQueryRequest { Id = id };
			return Ok(await Sender.Send(query));
		}
	}
}
