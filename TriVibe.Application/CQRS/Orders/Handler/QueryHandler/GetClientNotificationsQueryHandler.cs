using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Request;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.QueryHandler;

public class GetClientNotificationsQueryHandler : IRequestHandler<GetClientNotificationsQueryRequest, ResponseModel<List<GetClientNotificationsQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetClientNotificationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<List<GetClientNotificationsQueryResponse>>> Handle(GetClientNotificationsQueryRequest request, CancellationToken cancellationToken)
    {
        var notificationsList = await _unitOfWork.Notifications.GetAllAsync();
        var notifications = notificationsList
                            .Where(n => n.ClientId.HasValue && n.ClientId.Value == request.ClientId)
                            .OrderByDescending(n => n.CreatedDate)
                            .ToList();

        var response = notifications.Select(n => new GetClientNotificationsQueryResponse
        {
            Id = n.Id,
            WorkerId = n.WorkerId,
            ClientId = n.ClientId,
            OrderId = n.OrderId,
            Message = n.Message,
            IsRead = n.IsRead,
            CreatedDate = n.CreatedDate
        }).ToList();

        return new ResponseModel<List<GetClientNotificationsQueryResponse>>(response);
    }
}
