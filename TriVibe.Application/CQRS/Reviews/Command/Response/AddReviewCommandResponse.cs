namespace TriVibe.Application.CQRS.Reviews.Command.Response;

public class AddReviewCommandResponse
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public string Author { get; set; }
    public Guid BarberId { get; set; }
}
