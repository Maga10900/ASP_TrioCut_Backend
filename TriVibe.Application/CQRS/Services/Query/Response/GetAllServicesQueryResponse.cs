namespace TriVibe.Application.CQRS.Services.Query.Response;

public class GetAllServicesQueryResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public double Price { get; set; }
	public string Description { get; set; }
	public int DurationInMinutes { get; set; }
}
