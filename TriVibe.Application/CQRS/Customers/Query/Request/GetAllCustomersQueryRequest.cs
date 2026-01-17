using MediatR;
using TriVibe.Application.CQRS.Customers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Customers.Query.Request;

public class GetAllCustomersQueryRequest:IRequest<Pagination<GetAllCustomersQueryResponse>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}
