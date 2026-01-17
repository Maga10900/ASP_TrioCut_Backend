using MediatR;
using TriVibe.Application.CQRS.Appointments.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Appointments.Query.Request;

public class GetByBarberEmailQueryRequest:IRequest<Pagination<GetByBarberEmailQueryResponse>>
{
    public string BarberEmail { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}
