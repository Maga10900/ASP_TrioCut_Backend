using MediatR;

namespace TriVibe.Application.CQRS.Notifications.Command.Request;

public class UpdateNotificationCommandRequest : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
}
