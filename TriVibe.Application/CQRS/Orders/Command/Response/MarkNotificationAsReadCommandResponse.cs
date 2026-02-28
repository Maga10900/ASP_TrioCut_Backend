namespace TriVibe.Application.CQRS.Orders.Command.Response;

public class MarkNotificationAsReadCommandResponse
{
    public bool Success { get; set; }
    public Guid NotificationId { get; set; }
    public string Message { get; set; } = null!;
}
