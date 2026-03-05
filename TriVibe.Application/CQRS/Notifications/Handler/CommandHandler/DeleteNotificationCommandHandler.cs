using MediatR;
using TriVibe.Application.CQRS.Notifications.Command.Request;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Notifications.Handler.CommandHandler;

public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteNotificationCommandRequest request, CancellationToken cancellationToken)
    {
        var notification = await _unitOfWork.Notifications.GetByIdAsync(request.Id);
        if (notification == null) return false;

        await _unitOfWork.Notifications.DeleteAsync(notification);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
