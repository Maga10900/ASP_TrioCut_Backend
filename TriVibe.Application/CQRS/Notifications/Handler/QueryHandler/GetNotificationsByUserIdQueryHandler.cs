using MediatR;
using TriVibe.Application.CQRS.Notifications.Query.Request;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Notifications.Handler.QueryHandler;

public class GetNotificationsByUserIdQueryHandler : IRequestHandler<GetNotificationsByUserIdQueryRequest, List<Notification>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationsByUserIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Notification>> Handle(GetNotificationsByUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        var allNotifications = await _unitOfWork.Notifications.GetAllAsync();
        return allNotifications
            .Where(n => n.ClientId == request.UserId || n.WorkerId == request.UserId)
            .ToList();
    }
}
