using MediatR;
using TriVibe.Application.CQRS.Workers.Command.Request;
using TriVibe.Application.CQRS.Workers.Command.Response;
using TriVibe.Common.Extensions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Workers.Handler.CommandHandler;

public class AddWorkerCommandHandler : IRequestHandler<AddWorkerCommandRequest, ResponseModel<AddWorkerCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddWorkerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddWorkerCommandResponse>> Handle(AddWorkerCommandRequest request, CancellationToken cancellationToken)
    {
        var hashedPass = PasswordHasher.ComputeStringToSha256Hash(request.Password);
        var worker = new Worker
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = hashedPass,
            PhoneNumber = request.PhoneNumber,
            Age = request.Age,
            ProfilePhoto = request.ProfilePhoto,
            Description = request.Description,
            Rating = request.Rating,
            Job = request.Job,
            UserType = UserType.Worker
        };
        
        await _unitOfWork.Workers.AddAsync(worker);
        await _unitOfWork.SaveChangesAsync();
        
        var response = new AddWorkerCommandResponse
        {
            Success = true,
            FirstName = worker.FirstName,
            LastName = worker.LastName,
            Email = worker.Email
        };
        
        return new ResponseModel<AddWorkerCommandResponse>(response);
    }
}
