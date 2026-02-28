using MediatR;
using TriVibe.Application.CQRS.Workers.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;

namespace TriVibe.Application.CQRS.Workers.Query.Request;

public class GetAllWorkerQueryRequest : IRequest<ResponseModel<List<GetAllWorkerQueryResponse>>>
{
}
