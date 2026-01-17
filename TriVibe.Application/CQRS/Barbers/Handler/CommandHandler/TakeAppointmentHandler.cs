using MediatR;
using TriVibe.Application.CQRS.Barbers.Command.Request;
using TriVibe.Application.CQRS.Barbers.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Barbers.Handler.CommandHandler;

public class TakeAppointmentHandler : IRequestHandler<TakeAppointmentRequest, ResponseModel<TakeAppointmentResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public TakeAppointmentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<TakeAppointmentResponse>> Handle(TakeAppointmentRequest request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.Barbers.TakeAppointment(request.AppointmentId);
        await _unitOfWork.SaveChangesAsync();
        var response = new TakeAppointmentResponse
        {
            Status = AppointmentStatus.Confirmed
        };
        return new ResponseModel<TakeAppointmentResponse>(response);
    }
}
