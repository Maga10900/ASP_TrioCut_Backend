namespace TriVibe.Application.CQRS.Services.Query.Response;

public class GetByIdServiceQueryResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public double Price { get; set; }
	public int DurationInMinutes { get; set; }

}
