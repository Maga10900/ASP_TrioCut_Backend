using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Barbers.Handler.CommandHandler;

public class DeclineAppointmentHandler : IRequestHandler<DeclineAppointmentRequest, ResponseModel<DeclineAppointmentResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeclineAppointmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseModel<DeclineAppointmentResponse>> Handle(DeclineAppointmentRequest request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.Barbers.DeclineAppointment(request.AppointmentId);
        await _unitOfWork.SaveChangesAsync();
        var response = new DeclineAppointmentResponse { Status = appointment.Status };
        return new ResponseModel<DeclineAppointmentResponse>(response);
    }
}
