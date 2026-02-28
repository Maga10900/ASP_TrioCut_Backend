using MediatR;
using TriVibe.Application.CQRS.Clients.Command.Request;
using TriVibe.Application.CQRS.Clients.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Clients.Handler.CommandHandler;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommandRequest, ResponseModel<UpdateClientCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateClientCommandResponse>> Handle(UpdateClientCommandRequest request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id);

        client.FirstName = request.FirstName;
        client.LastName = request.LastName;
        client.Email = request.Email;
        client.PhoneNumber = request.PhoneNumber;
        client.Age = request.Age;
        client.ProfilePhoto = request.ProfilePhoto;
        client.Description = request.Description;
        client.Rating = request.Rating;

        _unitOfWork.Clients.Update(client);
        await _unitOfWork.SaveChangesAsync();

        var response = new UpdateClientCommandResponse
        {
            Success = true,
            FirstName = client.FirstName,
            LastName = client.LastName
        };

        return new ResponseModel<UpdateClientCommandResponse>(response);
    }
}
