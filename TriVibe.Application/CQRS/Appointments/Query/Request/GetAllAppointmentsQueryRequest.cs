using MediatR;
using TriVibe.Application.CQRS.Appointments.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Appointments.Query.Request;

public class GetAllAppointmentsQueryRequest:IRequest<Pagination<GetAllAppointmentsQueryResponse>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}
