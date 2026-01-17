using TriVibe.Domain;

namespace TriVibe.Application.CQRS.Appointments.Command.Response;

public class UpdateAppointmentCommandResponse
{
 public Guid Id { get; set; }
 public DateTime AppointmentDate { get; set; }
 public AppointmentStatus Status { get; set; }
 public string BarberEmail { get; set; }
 public string CustomerEmail { get; set; }
 public string ServiceName { get; set; }
}
