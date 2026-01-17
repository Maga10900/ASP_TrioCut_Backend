
namespace TriVibe.Application.CQRS.Reviews.Query.Response;

public class GetByBarberIdReviewQueryResponse
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public string Author { get; set; }
    public Guid BarberId { get; set; }
}
