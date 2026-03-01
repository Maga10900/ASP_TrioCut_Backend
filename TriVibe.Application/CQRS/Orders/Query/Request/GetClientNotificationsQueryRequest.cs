using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Query.Request;

public class GetClientNotificationsQueryRequest : IRequest<ResponseModel<List<GetClientNotificationsQueryResponse>>>
{
    public Guid ClientId { get; set; }
}
