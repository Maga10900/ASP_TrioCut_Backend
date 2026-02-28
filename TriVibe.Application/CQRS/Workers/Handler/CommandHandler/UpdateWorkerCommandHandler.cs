using MediatR;
using TriVibe.Application.CQRS.Workers.Command.Request;
using TriVibe.Application.CQRS.Workers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Workers.Handler.CommandHandler;

public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommandRequest, ResponseModel<UpdateWorkerCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWorkerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateWorkerCommandResponse>> Handle(UpdateWorkerCommandRequest request, CancellationToken cancellationToken)
    {
        var worker = await _unitOfWork.Workers.GetByIdAsync(request.Id);
        
        worker.FirstName = request.FirstName;
        worker.LastName = request.LastName;
        worker.PhoneNumber = request.PhoneNumber;
        worker.Age = request.Age;
        worker.ProfilePhoto = request.ProfilePhoto;
        worker.Description = request.Description;
        worker.Rating = request.Rating;
        worker.Job = request.Job;
        
        _unitOfWork.Workers.Update(worker);
        await _unitOfWork.SaveChangesAsync();
        
        var response = new UpdateWorkerCommandResponse
        {
            Success = true,
            Message = "Worker updated successfully"
        };
        
        return new ResponseModel<UpdateWorkerCommandResponse>(response);
    }
}
