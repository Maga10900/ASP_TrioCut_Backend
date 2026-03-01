using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Query.Request;

public class GetOrdersByClientIdQueryRequest : IRequest<ResponseModel<List<GetOrdersByClientIdQueryResponse>>>
{
    public Guid ClientId { get; set; }
}
