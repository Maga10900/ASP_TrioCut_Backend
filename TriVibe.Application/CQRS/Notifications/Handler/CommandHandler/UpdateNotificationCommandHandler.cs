using MediatR;
using TriVibe.Application.CQRS.Notifications.Command.Request;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Notifications.Handler.CommandHandler;

public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateNotificationCommandRequest request, CancellationToken cancellationToken)
    {
        var notification = await _unitOfWork.Notifications.GetByIdAsync(request.Id);
        if (notification == null) return false;

        notification.Message = request.Message;
        notification.IsRead = request.IsRead;

        _unitOfWork.Notifications.Update(notification);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
