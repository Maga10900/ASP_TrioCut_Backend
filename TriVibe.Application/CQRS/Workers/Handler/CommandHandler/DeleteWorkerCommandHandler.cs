using MediatR;
using TriVibe.Application.CQRS.Workers.Command.Request;
using TriVibe.Application.CQRS.Workers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Workers.Handler.CommandHandler;

public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommandRequest, ResponseModel<DeleteWorkerCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWorkerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteWorkerCommandResponse>> Handle(DeleteWorkerCommandRequest request, CancellationToken cancellationToken)
    {
        var worker = await _unitOfWork.Workers.GetByIdAsync(request.Id);
        
        await _unitOfWork.Workers.DeleteProfileAsync(worker);
        
        var response = new DeleteWorkerCommandResponse
        {
            Success = true,
            Message = "Worker deleted successfully"
        };
        
        return new ResponseModel<DeleteWorkerCommandResponse>(response);
    }
}
