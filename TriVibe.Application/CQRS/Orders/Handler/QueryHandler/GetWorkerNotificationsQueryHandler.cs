using MediatR;
using TriVibe.Application.CQRS.Orders.Query.Request;
using TriVibe.Application.CQRS.Orders.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.QueryHandler;

public class GetWorkerNotificationsQueryHandler : IRequestHandler<GetWorkerNotificationsQueryRequest, ResponseModel<List<GetWorkerNotificationsQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkerNotificationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<List<GetWorkerNotificationsQueryResponse>>> Handle(GetWorkerNotificationsQueryRequest request, CancellationToken cancellationToken)
    {
        var notificationsList = await _unitOfWork.Notifications.GetAllAsync();
        var notifications = notificationsList
                            .Where(n => n.WorkerId == request.WorkerId)
                            .OrderByDescending(n => n.CreatedDate)
                            .ToList();

        var response = notifications.Select(n => new GetWorkerNotificationsQueryResponse
        {
            Id = n.Id,
            WorkerId = n.WorkerId,
            OrderId = n.OrderId,
            Message = n.Message,
            IsRead = n.IsRead,
            CreatedDate = n.CreatedDate // Ensure BaseEntity has CreatedDate
        }).ToList();

        return new ResponseModel<List<GetWorkerNotificationsQueryResponse>>(response);
    }
}
