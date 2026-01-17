using TriVibe.Domain;

namespace TriVibe.Application.CQRS.Barbers.Command.Response;

public class TakeAppointmentResponse
{
    public AppointmentStatus Status { get; set; }    
}
