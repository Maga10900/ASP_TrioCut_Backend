using MediatR;
using TriVibe.Application.CQRS.Notifications.Command.Request;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Notifications.Handler.CommandHandler;

public class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommandRequest, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddNotificationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddNotificationCommandRequest request, CancellationToken cancellationToken)
    {
        var notification = new Notification
        {
            WorkerId = request.WorkerId,
            ClientId = request.ClientId,
            OrderId = request.OrderId,
            Message = request.Message,
            IsRead = false
        };

        await _unitOfWork.Notifications.AddAsync(notification);
        await _unitOfWork.SaveChangesAsync();

        return notification.Id;
    }
}
