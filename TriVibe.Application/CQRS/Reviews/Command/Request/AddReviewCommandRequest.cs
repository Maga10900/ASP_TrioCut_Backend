using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Application.CQRS.Reviews.Command.Response;

namespace TriVibe.Application.CQRS.Reviews.Command.Request;

public class AddReviewCommandRequest : IRequest<ResponseModel<AddReviewCommandResponse>>
{
    public string Author { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public Guid BarberId { get; set; }
}
