using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibe.Application.CQRS.Barbers.Query.Request;
using TriVibe.Application.CQRS.Customers.Command.Request;
using TriVibe.Application.CQRS.Customers.Query.Request;
using TriVibeWebApi.Constants;

namespace TriVibeWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = $"{UserRoles.Admin}")]
    public class CustomerController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            return Ok(await Sender.Send(new DeleteCustomerCommandRequest() { Id = id }));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersQueryRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpPut]
        [Authorize(Roles = $"{UserRoles.Admin}, {UserRoles.Customer}")]
        [AllowAnonymous]    
		public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var query = new GetByIdCustomerQueryRequest { Id = id };
            return Ok(await Sender.Send(query));
        }
    }
}
