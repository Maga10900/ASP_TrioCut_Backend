using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Query.Request;

public class GetWorkerNotificationsQueryRequest : IRequest<ResponseModel<List<GetWorkerNotificationsQueryResponse>>>
{
    public Guid WorkerId { get; set; }
}
