using MediatR;
using TriVibe.Application.CQRS.Services.Query.Request;
using TriVibe.Application.CQRS.Services.Query.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Services.Handler.QueryHandler;

public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQueryRequest, Pagination<GetAllServicesQueryResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	
	public GetAllServicesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	
	async Task<Pagination<GetAllServicesQueryResponse>> IRequestHandler<GetAllServicesQueryRequest, Pagination<GetAllServicesQueryResponse>>.Handle(GetAllServicesQueryRequest request, CancellationToken cancellationToken)
	{
		var services = await _unitOfWork.Services.GetAllAsync();
		var totalItems = services.Count;
		var pagedServices = services
			.Skip((request.Page - 1) * request.Size)
			.Take(request.Size)
			.Select(s => new GetAllServicesQueryResponse
			{
				Id = s.Id,
				Name = s.Name,
				Price = s.Price,
                DurationInMinutes = s.DurationInMinutes
			})
			.ToList();
		var response = new Pagination<GetAllServicesQueryResponse>(pagedServices, totalItems, request.Page, request.Size);
		return response;
	}
}
