namespace TriVibe.Application.CQRS.Clients.Command.Response;

public class UpdateClientCommandResponse
{
    public bool Success { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
