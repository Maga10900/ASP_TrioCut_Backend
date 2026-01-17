using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.Exceptions;
using TriVibe.Common.Extensions;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Barbers.Handler.CommandHandler;

public class UpdateBarberCommandHandler : IRequestHandler<UpdateBarberCommandRequest, ResponseModel<UpdateBarberCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateBarberCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateBarberCommandResponse>> Handle(UpdateBarberCommandRequest request, CancellationToken cancellationToken)
    {
        var barber = await _unitOfWork.Barbers.GetByIdAsync(request.Id);
        if (barber == null)
        {
            throw new NotFoundException("Barber not found");
        }
        var hashedPass = PasswordHasher.ComputeStringToSha256Hash(request.Password);
        barber.FirstName = request.FirstName;
        barber.Description = request.Description;
        barber.LastName = request.LastName;
        barber.Email = request.Email;
        barber.PasswordHash = hashedPass;
        barber.PhoneNumber = request.PhoneNumber;
        barber.Age = request.Age;
        barber.ImageUrl = request.ImageUrl;
        _unitOfWork.Barbers.Update(barber);
        await _unitOfWork.SaveChangesAsync();
        var response = new UpdateBarberCommandResponse()
        {
            Id = barber.Id,
            FirstName = barber.FirstName,
            LastName = barber.LastName,
            Email = barber.Email,
            PhoneNumber = barber.PhoneNumber,
            Age = barber.Age,
            ImageUrl = barber.ImageUrl,
            Description = barber.Description
        };
        return new ResponseModel<UpdateBarberCommandResponse>(response);
    }
}
