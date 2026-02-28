namespace TriVibe.Application.CQRS.Orders.Query.Response;

public class GetWorkerNotificationsQueryResponse
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public Guid? OrderId { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime CreatedDate { get; set; }
}
