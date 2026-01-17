using MediatR;
using TriVibe.Application.CQRS.Reviews.Command.Request;
using TriVibe.Application.CQRS.Reviews.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Reviews.Handler.CommandHandler;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, ResponseModel<UpdateReviewCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseModel<UpdateReviewCommandResponse>> Handle(UpdateReviewCommandRequest request, CancellationToken cancellationToken)
    {
        var review = await _unitOfWork.Reviews.GetByIdAsync(request.ReviewId);
        if (request.Rating.HasValue) review.Rating = request.Rating.Value;
        if (!string.IsNullOrWhiteSpace(request.Comment)) review.Comment = request.Comment;
        await _unitOfWork.Reviews.Update(review);
        await _unitOfWork.SaveChangesAsync();
        var response = new UpdateReviewCommandResponse { Id = review.Id, Rating = review.Rating, Comment = review.Comment };
        return new ResponseModel<UpdateReviewCommandResponse>(response);
    }
}
