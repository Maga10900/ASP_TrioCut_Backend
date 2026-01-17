using TriVibe.Domain;

namespace TriVibe.Application.CQRS.Appointments.Query.Response;

public class GetByBarberEmailQueryResponse
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string ServiceName { get; set; }
}
