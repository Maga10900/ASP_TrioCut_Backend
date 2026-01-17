using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Application.CQRS.Reviews.Query.Response;

namespace TriVibe.Application.CQRS.Reviews.Query.Request;

public class GetAllReviewsQueryRequest : IRequest<Pagination<GetAllReviewsQueryResponse>>
{
    public int Page { get; set; }
    public int Size { get; set; }
}
