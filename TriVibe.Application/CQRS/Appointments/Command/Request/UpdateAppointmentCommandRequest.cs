using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Application.CQRS.Appointments.Command.Response;
using TriVibe.Domain;

namespace TriVibe.Application.CQRS.Appointments.Command.Request;

public class UpdateAppointmentCommandRequest : IRequest<ResponseModel<UpdateAppointmentCommandResponse>>
{
 public Guid AppointmentId { get; set; }
 public DateTime? AppointmentDate { get; set; }
 public AppointmentStatus? Status { get; set; }
 public string? BarberEmail { get; set; }
 public string? CustomerEmail { get; set; }
 public string? ServiceName { get; set; }
}
