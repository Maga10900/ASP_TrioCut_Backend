using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Query.Request;

public class GetOrderByIdQueryRequest : IRequest<ResponseModel<GetOrderByIdQueryResponse>>
{
    public Guid Id { get; set; }
}
