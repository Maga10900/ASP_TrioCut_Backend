namespace TriVibe.Application.CQRS.Users.Command.Response;

public class RegistrationUserCommandResponse
{
	public Guid Id { get; set; }
	public string Firstname { get; set; }
	public string Lastname { get; set; }
	public string Email { get; set; }
}
