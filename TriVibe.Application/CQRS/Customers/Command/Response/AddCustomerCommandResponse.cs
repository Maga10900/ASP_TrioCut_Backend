namespace TriVibe.Application.CQRS.Customers.Command.Response;

public class AddCustomerCommandResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }

}
