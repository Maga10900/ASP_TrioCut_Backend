using TriVibe.Domain.Entities.BaseEntities;

namespace TriVibe.Domain.Entities.Concretes;

public class Notification : BaseEntity
{
    public Guid? WorkerId { get; set; }
    public Worker? Worker { get; set; }

    public Guid? ClientId { get; set; }
    public Client? Client { get; set; }

    public Guid? OrderId { get; set; }  // Optional, if it's related to an order

    public string Message { get; set; } = null!;
    public bool IsRead { get; set; } = false;
}
