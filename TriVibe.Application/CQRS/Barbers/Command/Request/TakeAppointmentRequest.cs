using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Application.CQRS.Barbers.Command.Response;

namespace TriVibe.Application.CQRS.Barbers.Command.Request;

public class TakeAppointmentRequest : IRequest<ResponseModel<TakeAppointmentResponse>>
{
 public Guid AppointmentId { get; set; }
}
