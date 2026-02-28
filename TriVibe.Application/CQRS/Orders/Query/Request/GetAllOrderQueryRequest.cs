using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Query.Request;

public class GetAllOrderQueryRequest : IRequest<ResponseModel<List<GetAllOrderQueryResponse>>>
{
}
