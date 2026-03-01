namespace TriVibe.Application.CQRS.Orders.Query.Response;

public class GetClientNotificationsQueryResponse
{
    public Guid Id { get; set; }
    public Guid? WorkerId { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? OrderId { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime CreatedDate { get; set; }
}
