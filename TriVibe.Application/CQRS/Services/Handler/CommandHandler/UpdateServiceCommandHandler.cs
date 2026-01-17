using MediatR;
using TriVibe.Application.CQRS.Services.Command.Requset;
using TriVibe.Application.CQRS.Services.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Services.Handler.CommandHandler;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommandRequest, ResponseModel<UpdateServiceCommandResponse>>
{
	private readonly IUnitOfWork _unitOfWork;
	public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<ResponseModel<UpdateServiceCommandResponse>> Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
	{
		var service = await _unitOfWork.Services.GetByIdAsync(request.Id);

		service.Name = request.Name;
		service.Price = request.Price;
		service.DurationInMinutes = request.DurationInMinutes;
		_unitOfWork.Services.UpdateAsync(service);
		await _unitOfWork.SaveChangesAsync();
		var response = new UpdateServiceCommandResponse
		{
			Id = service.Id,
			Name = service.Name,
			Price = service.Price,
			DurationInMinutes = service.DurationInMinutes
		};

		return new ResponseModel<UpdateServiceCommandResponse>(response);
	}
}
