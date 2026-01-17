namespace TriVibe.Application.CQRS.Services.Command.Response;

public class AddServiceCommandResponse
{
	public bool Success { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public int DurationInMinutes { get; set; }
}
