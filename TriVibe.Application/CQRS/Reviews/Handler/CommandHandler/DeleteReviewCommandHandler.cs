using MediatR;
using TriVibe.Application.CQRS.Reviews.Command.Request;
using TriVibe.Application.CQRS.Reviews.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Reviews.Handler.CommandHandler;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, ResponseModel<DeleteReviewCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseModel<DeleteReviewCommandResponse>> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
    {
        var review = await _unitOfWork.Reviews.GetByIdAsync(request.ReviewId);
        await _unitOfWork.Reviews.DeleteAsync(review);
        await _unitOfWork.SaveChangesAsync();
        var response = new DeleteReviewCommandResponse { Success = true };
        return new ResponseModel<DeleteReviewCommandResponse>(response);
    }
}
