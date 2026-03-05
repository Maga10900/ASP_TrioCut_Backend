using MediatR;
using TriVibe.Application.CQRS.Notifications.Query.Request;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Notifications.Handler.QueryHandler;

public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQueryRequest, Notification>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNotificationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Notification> Handle(GetNotificationByIdQueryRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Notifications.GetByIdAsync(request.Id);
    }
}
