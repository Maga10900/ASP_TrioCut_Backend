namespace TriVibe.Application.CQRS.Orders.Command.Response;

public class UpdateOrderStatusCommandResponse
{
    public bool Success { get; set; }
    public Guid OrderId { get; set; }
    public string Message { get; set; } = null!;
}
