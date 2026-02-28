using TriVibe.Domain.Entities.BaseEntities;

namespace TriVibe.Domain.Entities.Concretes;

public class Review : BaseEntity
{
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public Barber? Barber { get; set; }
    public Guid? BarberId { get; set; }
    public Worker? Worker { get; set; }
    public Guid? WorkerId { get; set; }
    public Client? Client { get; set; }
    public Guid? ClientId { get; set; }
    public string Author { get; set; }
}
