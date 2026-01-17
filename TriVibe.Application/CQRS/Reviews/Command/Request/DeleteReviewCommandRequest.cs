using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Application.CQRS.Reviews.Command.Response;

namespace TriVibe.Application.CQRS.Reviews.Command.Request;

public class DeleteReviewCommandRequest : IRequest<ResponseModel<DeleteReviewCommandResponse>>
{
    public Guid ReviewId { get; set; }
}
