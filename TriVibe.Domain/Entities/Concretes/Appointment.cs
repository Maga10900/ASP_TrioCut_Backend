using TriVibe.Domain.Entities.BaseEntities;

namespace TriVibe.Domain.Entities.Concretes;

public class Appointment:BaseEntity
{
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; }
    public string BarberEmail { get; set; }
    public string CustomerEmail { get; set; }
    public string ServiceName { get; set; }
}
