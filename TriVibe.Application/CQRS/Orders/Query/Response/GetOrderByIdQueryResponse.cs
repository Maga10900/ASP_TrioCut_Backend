namespace TriVibe.Application.CQRS.Orders.Query.Response;

public class GetOrderByIdQueryResponse
{
    public Guid Id { get; set; }
    public Guid WorkerId { get; set; }
    public decimal Salary { get; set; }
    public string Address { get; set; }
    public List<string>? Photos { get; set; }
    public string? Details { get; set; }
    public DateTime CreatedDate { get; set; }
}
