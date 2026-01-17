using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IAppointmentRepository
{
    Task<Appointment> AddAsync(Appointment appointment);
    Task DeleteAsync(Appointment appointment);
    Task<List<Appointment>> GetAllAsync();
    Task<List<Appointment>> GetByBarberEmailAsync(string barberEmail);
    Task<List<Appointment>> GetByCustomerEmailAsync(string customerEmail);
    Task<Appointment> GetByIdAsync(Guid Id);
    Task Update(Appointment appointment);
}
