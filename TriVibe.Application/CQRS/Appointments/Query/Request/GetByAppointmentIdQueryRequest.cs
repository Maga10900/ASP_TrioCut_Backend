using MediatR;
using TriVibe.Application.CQRS.Appointments.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Appointments.Query.Request;

public class GetByAppointmentIdQueryRequest : IRequest<ResponseModel<GetByAppointmentIdQueryResponse>>
{
    public Guid AppointmentId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}
