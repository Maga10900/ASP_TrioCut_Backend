using TriVibe.Domain.Entities.BaseEntities;
namespace TriVibe.Domain.Entities.Concretes;

public class Barber: User
{
	public string? ImageUrl { get; set; }//Profil Sekli
	public string? Description { get; set; }// Haqqında qısa məlumat
	public double Rating { get; set; } // Bərbərin reytinqi
	 
    // Bir bərbərin bir neçə xidməti ola bilər
    public List<Service> Services { get; set; }

	// Bir bərbərin bir neçə appointment-i ola bilər
	public List<Customer>? Customers { get; set; }

	// Reviews for the barber
	public List<Review>? Reviews { get; set; }

}
