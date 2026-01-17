using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Domain.DTOs;

public class BarberDto
{
	public Guid Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public double Rating { get; set; }
	public List<Service> Services { get; set; }
	public List<Customer> Customers { get; set; }

}
