using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Application.CQRS.Reviews.Command.Response;

namespace TriVibe.Application.CQRS.Reviews.Command.Request;

public class UpdateReviewCommandRequest : IRequest<ResponseModel<UpdateReviewCommandResponse>>
{
    public Guid ReviewId { get; set; }
    public int? Rating { get; set; }
    public string? Comment { get; set; }
}
