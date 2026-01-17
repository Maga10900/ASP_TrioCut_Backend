using TriVibe.Domain;
using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Application.CQRS.Appointments.Query.Response;

public class GetAllAppointmentsQueryResponse
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public string BarberEmail { get; set; }
    public string CustomerEmail { get; set; }
    public string ServiceName { get; set; }
    public double ServicePrice { get; set; }
}
