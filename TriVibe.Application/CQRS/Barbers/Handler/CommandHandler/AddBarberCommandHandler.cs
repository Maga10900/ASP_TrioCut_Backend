using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.Extensions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;
namespace TriVibe.Application.CQRS.Barbers.Handler.CommandHandler;

public class AddBarberCommandHandler:IRequestHandler<AddBarberCommandRequest, ResponseModel<AddBarberCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddBarberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddBarberCommandResponse>> Handle(AddBarberCommandRequest request, CancellationToken cancellationToken)
    {
        var hashedPass = PasswordHasher.ComputeStringToSha256Hash(request.Password);
        var barber = new Barber
        {
            FirstName = request.FirstName,
            Description = request.Description,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = hashedPass,
            PhoneNumber = request.PhoneNumber,
            Age = request.Age,
            ImageUrl = request.ImageUrl,
            Rating = request.Rating,
            UserType = UserType.Barber
		};
        await _unitOfWork.Barbers.AddAsync(barber);
        await _unitOfWork.SaveChangesAsync();
        var response = new AddBarberCommandResponse
        {
            Succes = true,
            FirstName = barber.FirstName,
            LastName = barber.LastName,
            Email = barber.Email

        };
        return new ResponseModel<AddBarberCommandResponse>(response);
    }
}
