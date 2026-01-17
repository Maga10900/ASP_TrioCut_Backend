using TriVibe.Domain.Entities.BaseEntities;
namespace TriVibe.Domain.Entities.Concretes;

public class Customer:User
{
	public DateTime Date { get; set; }
	// Müştərinin sifarişləri

	public Guid ServiceId { get; set; }
	//public Service Service { get; set; }
	public Guid? BarberId { get; set; }
	public Barber? Barber { get; set; }
}
