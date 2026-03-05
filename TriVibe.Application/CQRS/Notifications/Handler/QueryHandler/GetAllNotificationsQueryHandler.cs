using MediatR;
using TriVibe.Application.CQRS.Notifications.Query.Request;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Notifications.Handler.QueryHandler;

public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQueryRequest, List<Notification>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNotificationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Notification>> Handle(GetAllNotificationsQueryRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Notifications.GetAllAsync();
    }
}
