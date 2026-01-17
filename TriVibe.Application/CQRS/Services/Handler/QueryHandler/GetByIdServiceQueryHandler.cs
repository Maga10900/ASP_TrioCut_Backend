using MediatR;

using TriVibe.Application.CQRS.Services.Query.Request;
using TriVibe.Application.CQRS.Services.Query.Response;
using TriVibe.Common.Exceptions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Services.Handler.QueryHandler;

public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQueryRequest, ResponseModel<GetByIdServiceQueryResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetByIdServiceQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<ResponseModel<GetByIdServiceQueryResponse>> Handle(GetByIdServiceQueryRequest request, CancellationToken cancellationToken)
	{
		var service = await _unitOfWork.Services.GetByIdAsync(request.Id);
		if (service == null)
		{
			throw new NotFoundException("Service not found");
		}
		var response = new GetByIdServiceQueryResponse
		{
			Id = service.Id,
			Name = service.Name,
			Price = service.Price,
			DurationInMinutes = service.DurationInMinutes
		};
		return new ResponseModel<GetByIdServiceQueryResponse>(response);
	}
}
