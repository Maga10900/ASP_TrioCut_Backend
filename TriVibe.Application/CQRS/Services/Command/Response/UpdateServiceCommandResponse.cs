namespace TriVibe.Application.CQRS.Services.Command.Response;

public class UpdateServiceCommandResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public double Price { get; set; }
	public int DurationInMinutes { get; set; }
}
