namespace TriVibe.Application.CQRS.Reviews.Command.Response;

public class UpdateReviewCommandResponse
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
