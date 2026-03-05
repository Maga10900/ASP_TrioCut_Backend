using MediatR;

namespace TriVibe.Application.CQRS.Notifications.Command.Request;

public class DeleteNotificationCommandRequest : IRequest<bool>
{
    public Guid Id { get; set; }
}
