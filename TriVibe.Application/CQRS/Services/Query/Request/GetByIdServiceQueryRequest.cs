using MediatR;
using TriVibe.Application.CQRS.Services.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
namespace TriVibe.Application.CQRS.Services.Query.Request;

public class GetByIdServiceQueryRequest:IRequest<ResponseModel<GetByIdServiceQueryResponse>>
{
	public Guid Id { get; set; }
}
