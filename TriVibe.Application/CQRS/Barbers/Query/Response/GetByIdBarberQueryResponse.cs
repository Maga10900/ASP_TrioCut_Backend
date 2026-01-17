namespace TriVibe.Application.CQRS.Barbers.Query.Response;

public class GetByIdBarberQueryResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
}
