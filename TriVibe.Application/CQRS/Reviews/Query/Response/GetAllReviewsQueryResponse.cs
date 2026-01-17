using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Application.CQRS.Reviews.Query.Response;

public class GetAllReviewsQueryResponse
{
    public Guid Id { get; set; }
    public string Author { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime Date { get; set; }
    public Guid BarberId { get; set; }
}
