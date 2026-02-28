using MediatR;
using TriVibe.Application.CQRS.Reviews.Command.Request;
using TriVibe.Application.CQRS.Reviews.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Reviews.Handler.CommandHandler;

public class AddReviewCommandHandler : IRequestHandler<AddReviewCommandRequest, ResponseModel<AddReviewCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public AddReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddReviewCommandResponse>> Handle(AddReviewCommandRequest request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            Rating = request.Rating,
            Comment = request.Comment,
            BarberId = request.BarberId,
            Author = request.Author,
            CreatedDate = DateTime.UtcNow
        };
        await _unitOfWork.Reviews.AddAsync(review);
        await _unitOfWork.SaveChangesAsync();

        var response = new AddReviewCommandResponse
        {
            Id = review.Id,
            Rating = review.Rating,
            Comment = review.Comment,
            Author = review.Author,
            BarberId = review.BarberId ?? Guid.Empty
        };
        return new ResponseModel<AddReviewCommandResponse>(response);
    }
}
