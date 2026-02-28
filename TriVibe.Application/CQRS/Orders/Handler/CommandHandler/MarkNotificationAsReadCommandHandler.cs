using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Request;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Orders.Handler.CommandHandler;

public class MarkNotificationAsReadCommandHandler : IRequestHandler<MarkNotificationAsReadCommandRequest, ResponseModel<MarkNotificationAsReadCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public MarkNotificationAsReadCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<MarkNotificationAsReadCommandResponse>> Handle(MarkNotificationAsReadCommandRequest request, CancellationToken cancellationToken)
    {
        var notificationsList = await _unitOfWork.Notifications.GetAllAsync();
        var notification = notificationsList.FirstOrDefault(n => n.Id == request.NotificationId);

        if (notification == null)
        {
            return new ResponseModel<MarkNotificationAsReadCommandResponse>(new MarkNotificationAsReadCommandResponse
            {
                Success = false,
                Message = "Notification not found."
            });
        }

        notification.IsRead = true;
        _unitOfWork.Notifications.Update(notification);
        await _unitOfWork.SaveChangesAsync();

        var response = new MarkNotificationAsReadCommandResponse
        {
            Success = true,
            NotificationId = notification.Id,
            Message = "Notification marked as read."
        };

        return new ResponseModel<MarkNotificationAsReadCommandResponse>(response);
    }
}
