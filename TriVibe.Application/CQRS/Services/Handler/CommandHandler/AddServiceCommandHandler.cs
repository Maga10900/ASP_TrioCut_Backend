using MediatR;

using Microsoft.Extensions.Configuration;

using TriVibe.Application.CQRS.Services.Command.Requset;
using TriVibe.Application.CQRS.Services.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Services.Handler.CommandHandler;

public class AddServiceCommandHandler : IRequestHandler<AddServiceCommandRequest, ResponseModel<AddServiceCommandResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IConfiguration configuration;


	public AddServiceCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
	{
		_unitOfWork = unitOfWork;
		this.configuration = configuration;
	}
	public async Task<ResponseModel<AddServiceCommandResponse>> Handle(AddServiceCommandRequest request, CancellationToken cancellationToken)
	{
		var service = new Service
		{
			Name = request.Name,
			Price = request.Price,
			DurationInMinutes = request.DurationInMinutes
		};
		await _unitOfWork.Services.AddAsync(service);
		await _unitOfWork.SaveChangesAsync();

		var response = new AddServiceCommandResponse
		{
			Success = true,
			Name = service.Name,
			DurationInMinutes = service.DurationInMinutes
		};

		return new ResponseModel<AddServiceCommandResponse>(response);
	}
}
