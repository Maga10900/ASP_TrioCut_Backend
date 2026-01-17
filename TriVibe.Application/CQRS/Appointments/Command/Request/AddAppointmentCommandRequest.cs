using MediatR;
using TriVibe.Application.CQRS.Appointments.Command.Response;
using TriVibe.Common.GlobalResponse.Generics;
using TriVibe.Domain;

namespace TriVibe.Application.CQRS.Appointments.Command.Request;

public class AddAppointmentCommandRequest:IRequest<ResponseModel<AddAppointmentCommandResponse>>
{
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public string BarberEmail { get; set; }
    public string CustomerEmail { get; set; }
    public string ServiceName { get; set; }
}
