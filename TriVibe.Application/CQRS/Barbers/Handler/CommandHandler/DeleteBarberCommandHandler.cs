using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Barbers.Handler.CommandHandler;

public class DeleteBarberCommandHandler : IRequestHandler<DeleteBarberCommandRequest, ResponseModel<DeleteBarberCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

public DeleteBarberCommandHandler(IUnitOfWork unitOfWork)
{
    _unitOfWork = unitOfWork;
}

    public async Task<ResponseModel<DeleteBarberCommandResponse>> Handle(DeleteBarberCommandRequest request, CancellationToken cancellationToken)
    {
        var barber = await _unitOfWork.Barbers.GetByIdAsync(request.Id);
        await _unitOfWork.Barbers.DeleteProfileAsync(barber);
        await _unitOfWork.SaveChangesAsync();
        var response = new DeleteBarberCommandResponse
        {
            Success = true
        };
        return new ResponseModel<DeleteBarberCommandResponse>(response);
    }
}
