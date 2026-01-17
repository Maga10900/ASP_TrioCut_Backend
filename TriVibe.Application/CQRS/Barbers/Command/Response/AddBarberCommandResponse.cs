namespace TriVibe.Application.CQRS.Barbers.Command.Response;

public class AddBarberCommandResponse
{
    public bool Succes { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
