using MediatR;
using TriVibe.Application.CQRS.Clients.Command.Request;
using TriVibe.Application.CQRS.Clients.Command.Response;
using TriVibe.Common.Extensions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Clients.Handler.CommandHandler;

public class AddClientCommandHandler : IRequestHandler<AddClientCommandRequest, ResponseModel<AddClientCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddClientCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddClientCommandResponse>> Handle(AddClientCommandRequest request, CancellationToken cancellationToken)
    {
        var hashedPass = PasswordHasher.ComputeStringToSha256Hash(request.Password);
        var client = new Client
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
            UserType = UserType.Client
        };

        await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.SaveChangesAsync();

        var response = new AddClientCommandResponse
        {
            Success = true,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email
        };

        return new ResponseModel<AddClientCommandResponse>(response);
    }
}
