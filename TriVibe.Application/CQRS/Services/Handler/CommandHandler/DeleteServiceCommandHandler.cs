using MediatR;

using TriVibe.Application.CQRS.Services.Command.Requset;
using TriVibe.Application.CQRS.Services.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Services.Handler.CommandHandler;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommandRequest, ResponseModel<DeleteServiceCommandResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteServiceCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<ResponseModel<DeleteServiceCommandResponse>> Handle(DeleteServiceCommandRequest request, CancellationToken cancellationToken)
	{
		await _unitOfWork.Services.DeleteAsync(request.Id);
		await _unitOfWork.SaveChangesAsync();
		var response = new DeleteServiceCommandResponse
		{
			Success = true
		};
		return new ResponseModel<DeleteServiceCommandResponse>(response);
	}
}
