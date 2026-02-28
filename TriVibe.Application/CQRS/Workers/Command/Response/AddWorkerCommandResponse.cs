namespace TriVibe.Application.CQRS.Workers.Command.Response;

public class AddWorkerCommandResponse
{
    public bool Success { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
