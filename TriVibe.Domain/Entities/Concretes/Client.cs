using TriVibe.Domain.Entities.BaseEntities;

namespace TriVibe.Domain.Entities.Concretes;

public class Client : User
{
    public string? ProfilePhoto { get; set; }
    public string? Description { get; set; }
    public double Rating { get; set; }

    // Bir klentin bir neçə işçisi ola bilər
    public List<Worker>? Workers { get; set; }

    // Bir klentin bir neçə rəyi ola bilər
    public List<Review>? Reviews { get; set; }
}
