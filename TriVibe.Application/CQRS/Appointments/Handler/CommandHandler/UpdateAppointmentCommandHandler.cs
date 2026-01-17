using MediatR;
using TriVibe.Application.CQRS.Appointments.Command.Request;
using TriVibe.Application.CQRS.Appointments.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Common;

namespace TriVibe.Application.CQRS.Appointments.Handler.CommandHandler;

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, ResponseModel<UpdateAppointmentCommandResponse>>
{
 private readonly IUnitOfWork _unitOfWork;
 public UpdateAppointmentCommandHandler(IUnitOfWork unitOfWork)
 {
 _unitOfWork = unitOfWork;
 }

 public async Task<ResponseModel<UpdateAppointmentCommandResponse>> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
 {
 var appointment = await _unitOfWork.Appointments.GetByIdAsync(request.AppointmentId);
 if (request.AppointmentDate.HasValue)
 appointment.AppointmentDate = request.AppointmentDate.Value;
 if (request.Status.HasValue)
 appointment.Status = request.Status.Value;
 if (!string.IsNullOrWhiteSpace(request.BarberEmail))
 appointment.BarberEmail = request.BarberEmail;
 if (!string.IsNullOrWhiteSpace(request.CustomerEmail))
 appointment.CustomerEmail = request.CustomerEmail;
 if (!string.IsNullOrWhiteSpace(request.ServiceName))
 appointment.ServiceName = request.ServiceName;

 await _unitOfWork.Appointments.Update(appointment);
 await _unitOfWork.SaveChangesAsync();

 var response = new UpdateAppointmentCommandResponse
 {
 Id = appointment.Id,
 AppointmentDate = appointment.AppointmentDate,
 Status = appointment.Status,
 BarberEmail = appointment.BarberEmail,
 CustomerEmail = appointment.CustomerEmail,
 ServiceName = appointment.ServiceName
 };
 return new ResponseModel<UpdateAppointmentCommandResponse>(response);
 }
}
