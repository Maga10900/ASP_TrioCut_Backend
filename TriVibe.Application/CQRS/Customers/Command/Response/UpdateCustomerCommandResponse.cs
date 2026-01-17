namespace TriVibe.Application.CQRS.Customers.Command.Response;

public class UpdateCustomerCommandResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
}
