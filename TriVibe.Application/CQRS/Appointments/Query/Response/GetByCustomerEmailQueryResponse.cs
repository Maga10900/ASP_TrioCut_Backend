using TriVibe.Domain;

namespace TriVibe.Application.CQRS.Appointments.Query.Response;

public class GetByCustomerEmailQueryResponse
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public string BarberEmail { get; set; }
    public string ServiceName { get; set; }
}
