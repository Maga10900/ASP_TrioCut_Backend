namespace TriVibe.Application.CQRS.Orders.Query.Response;

public class GetOrdersByClientIdQueryResponse
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public Guid? ClientId { get; set; }
    public decimal Salary { get; set; }
    public string Address { get; set; }
    public List<string>? Photos { get; set; }
    public string? Details { get; set; }
    public DateTime CreatedDate { get; set; }
    public TriVibe.Domain.Enums.OrderStatus Status { get; set; }
}
