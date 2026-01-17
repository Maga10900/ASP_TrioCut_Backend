using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriVibe.Application.CQRS.Appointments.Command.Request;
using TriVibe.Application.CQRS.Appointments.Query.Request;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibeWebApi.Constants;

namespace TriVibeWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddAppointment(AddAppointmentCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(DeleteAppointmentCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments([FromQuery] GetAllAppointmentsQueryRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetByBarberEmail([FromQuery] GetByBarberEmailQueryRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetByCustomerEmail([FromQuery] GetByCustomerEmailQueryRequest request)
        {
            return Ok(await Sender.Send(request));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByAppointmentId(Guid id)
        {
            var request = new GetByAppointmentIdQueryRequest { AppointmentId = id };
            return Ok (await Sender.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> TakeAppointment([FromBody] TakeAppointmentRequest request)
        {
            return Ok(await Sender.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> DeclineAppointment([FromBody] DeclineAppointmentRequest request)
        {
            return Ok(await Sender.Send(request));
        }
    }
}
