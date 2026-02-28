using MediatR;
using TriVibe.Application.CQRS.Orders.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Orders.Command.Request;

public class MarkNotificationAsReadCommandRequest : IRequest<ResponseModel<MarkNotificationAsReadCommandResponse>>
{
    public Guid NotificationId { get; set; }
}
