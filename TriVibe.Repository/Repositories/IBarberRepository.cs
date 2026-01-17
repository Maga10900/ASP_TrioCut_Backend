using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IBarberRepository
{
    Task<Barber> AddAsync(Barber barber);
    void Update(Barber barber);
    Task DeleteProfileAsync(Barber barber);
    Task<List<Barber>> GetAllAsync();
    Task<Barber> GetByIdAsync (Guid barberId);
    Task<List<Customer>> GetAppointments(Guid barberId);
    Task<Appointment> TakeAppointment(Guid appointmentId);
    Task<Appointment> DeclineAppointment(Guid appointmentId);
}
