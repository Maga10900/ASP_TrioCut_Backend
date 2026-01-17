using TriVibe.Domain;

namespace TriVibe.Application.CQRS.Barbers.Command.Response;

public class DeclineAppointmentResponse
{
 public AppointmentStatus Status { get; set; }
}
