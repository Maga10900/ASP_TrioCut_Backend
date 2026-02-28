using TriVibe.Domain.Entities.BaseEntities;

namespace TriVibe.Domain.Entities.Concretes;

public class Order : BaseEntity
{
    public decimal Salary { get; set; }
    public string Address { get; set; }
    public List<string>? Photos { get; set; }
    public string? Details { get; set; }
    
    public TriVibe.Domain.Enums.OrderStatus Status { get; set; } = TriVibe.Domain.Enums.OrderStatus.Pending;

    // FK to Worker
    public Guid WorkerId { get; set; }
    public Worker? Worker { get; set; }
}
