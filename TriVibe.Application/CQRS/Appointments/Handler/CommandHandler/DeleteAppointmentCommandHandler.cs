using MediatR;
using TriVibe.Application.CQRS.Appointments.Command.Request;
using TriVibe.Application.CQRS.Appointments.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Appointments.Handler.CommandHandler;

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommandRequest, ResponseModel<DeleteAppointmentCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteAppointmentCommandResponse>> Handle(DeleteAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);
        await _unitOfWork.Appointments.DeleteAsync(appointment);
        await _unitOfWork.SaveChangesAsync();
        var response = new DeleteAppointmentCommandResponse
        {
            Success = true // Set to true if deletion is successful.
        };
        return new ResponseModel<DeleteAppointmentCommandResponse>(response);
    }
}
