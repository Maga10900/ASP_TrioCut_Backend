namespace TriVibe.Application.CQRS.Clients.Command.Response;

public class AddClientCommandResponse
{
    public bool Success { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
