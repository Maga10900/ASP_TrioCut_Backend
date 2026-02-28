namespace TriVibe.Application.CQRS.Orders.Command.Response;

public class AddOrderCommandResponse
{
    public bool Success { get; set; }
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
}
