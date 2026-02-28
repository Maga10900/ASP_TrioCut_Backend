using TriVibe.Domain.Entities.BaseEntities;

namespace TriVibe.Domain.Entities.Concretes;

public class Worker : User
{
	public string? ProfilePhoto { get; set; }
	public string? Description { get; set; }
	public double Rating { get; set; }
	public string? Job { get; set; } 

	// Bir işçinin bir neçə rəyi ola bilər
	public List<Review>? Reviews { get; set; }

	public Guid? ClientId { get; set; }
	public Client? Client { get; set; }
}
