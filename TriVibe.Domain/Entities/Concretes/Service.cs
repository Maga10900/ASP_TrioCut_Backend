using TriVibe.Domain.Entities.BaseEntities;
namespace TriVibe.Domain.Entities.Concretes;

public class Service : BaseEntity
{
	public string Name { get; set; }
	public double Price { get; set; }
	public int DurationInMinutes { get; set; }
	public List<Barber> Barbers { get; set; }

}
