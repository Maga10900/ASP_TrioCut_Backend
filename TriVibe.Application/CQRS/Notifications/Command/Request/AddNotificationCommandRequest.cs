using MediatR;

namespace TriVibe.Application.CQRS.Notifications.Command.Request;

public class AddNotificationCommandRequest : IRequest<Guid>
{
    public Guid? WorkerId { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? OrderId { get; set; }
    public string Message { get; set; } = null!;
}
