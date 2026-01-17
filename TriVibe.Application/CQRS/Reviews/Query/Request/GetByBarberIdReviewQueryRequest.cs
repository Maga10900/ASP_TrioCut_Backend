using MediatR;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Application.CQRS.Reviews.Query.Response;

namespace TriVibe.Application.CQRS.Reviews.Query.Request;

public class GetByBarberIdReviewQueryRequest : IRequest<Pagination<GetByBarberIdReviewQueryResponse>>
{
    public Guid BarberId { get; set; }
    public int Page { get; set; } 
    public int Size { get; set; } 
}
