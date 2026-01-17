using MediatR;
using TriVibe.Application.CQRS.Reviews.Query.Request;
using TriVibe.Application.CQRS.Reviews.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Reviews.Handler.QueryHandler;

public class GetByBarberIdReviewQueryHandler : IRequestHandler<GetByBarberIdReviewQueryRequest, Pagination<GetByBarberIdReviewQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetByBarberIdReviewQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Pagination<GetByBarberIdReviewQueryResponse>> Handle(GetByBarberIdReviewQueryRequest request, CancellationToken cancellationToken)
    {
        var reviews = await _unitOfWork.Reviews.GetAllAsync();
        var barberReviews = reviews.Where(r => r.BarberId == request.BarberId).ToList();
        
        var total = barberReviews.Count;
        var paged = barberReviews.Skip((request.Page - 1) * request.Size).Take(request.Size).Select(r => new GetByBarberIdReviewQueryResponse 
        { 
            Id = r.Id, 
            Rating = r.Rating, 
            Comment = r.Comment, 
            BarberId = r.BarberId,
            Author = r.Author
        }).ToList();
        
        var response = new Pagination<GetByBarberIdReviewQueryResponse>(paged, total, request.Page, request.Size);
        return response;
    }
}
