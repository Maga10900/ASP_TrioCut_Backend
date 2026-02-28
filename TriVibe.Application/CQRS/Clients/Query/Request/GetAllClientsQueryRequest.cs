using MediatR;
using TriVibe.Application.CQRS.Clients.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Clients.Query.Request;

public class GetAllClientsQueryRequest : IRequest<ResponseModel<List<GetAllClientsQueryResponse>>>
{
}
