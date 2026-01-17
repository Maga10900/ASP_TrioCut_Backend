using MediatR;
using TriVibe.Application.CQRS.Services.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
namespace TriVibe.Application.CQRS.Services.Query.Request;

public class GetAllServicesQueryRequest: IRequest<Pagination<GetAllServicesQueryResponse>>
{
	public int Page { get; set; }
	public int Size { get; set; }
}
