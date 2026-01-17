using MediatR;
using TriVibe.Application.CQRS.Appointments.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Appointments.Command.Request;

public class DeleteAppointmentCommandRequest:IRequest<ResponseModel<DeleteAppointmentCommandResponse>>
{
    public Guid AppointmentId { get; set; }
     
}
