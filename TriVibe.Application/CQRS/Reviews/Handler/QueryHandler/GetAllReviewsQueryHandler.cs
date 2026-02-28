using MediatR;
using TriVibe.Application.CQRS.Reviews.Query.Request;
using TriVibe.Application.CQRS.Reviews.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Reviews.Handler.QueryHandler;

public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQueryRequest, Pagination<GetAllReviewsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllReviewsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Pagination<GetAllReviewsQueryResponse>> Handle(GetAllReviewsQueryRequest request, CancellationToken cancellationToken)
    {
        var reviews = await _unitOfWork.Reviews.GetAllAsync();
        var total = reviews.Count;
        var paged = reviews.Skip((request.Page - 1) * request.Size).Take(request.Size).Select(r => new GetAllReviewsQueryResponse { Id = r.Id, Rating = r.Rating, Comment = r.Comment, BarberId = r.BarberId ?? Guid.Empty,Date = r.CreatedDate, Author= r.Author }).ToList();
        var response = new Pagination<GetAllReviewsQueryResponse>(paged, total, request.Page, request.Size);
        return response;
    }
}
