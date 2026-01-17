using MediatR;
using TriVibe.Application.CQRS.Barbers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Barbers.Query.Request;

public class GetAllBarbersQueryRequest : IRequest<Pagination<GetAllBarbersQueryResponse>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}
