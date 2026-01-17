using MediatR;
using TriVibe.Application.CQRS.Appointments.Command.Request;
using TriVibe.Application.CQRS.Appointments.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Appointments.Handler.CommandHandler;

public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommandRequest, ResponseModel<AddAppointmentCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public AddAppointmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<AddAppointmentCommandResponse>> Handle(AddAppointmentCommandRequest request, CancellationToken cancellationToken)
    {
        var app = new Appointment
        {
            AppointmentDate = request.AppointmentDate,
            Status = request.Status,
            BarberEmail = request.BarberEmail,
            CustomerEmail = request.CustomerEmail,
            ServiceName = request.ServiceName
        };
       await _unitOfWork.Appointments.AddAsync(app);
       await _unitOfWork.SaveChangesAsync();
        var response = new AddAppointmentCommandResponse
        {
            Id = app.Id,
            BarberEmail = app.BarberEmail,
            CustomerEmail = app.CustomerEmail,
            ServiceName = app.ServiceName
        };
        return new ResponseModel<AddAppointmentCommandResponse>(response);
    }
}
