using TriVibe.Domain;
namespace TriVibe.Application.CQRS.Customers.Query.Response;

public class GetAllCustomersQueryResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserType UserType { get; set; }
    public int Age { get; set; }

}
