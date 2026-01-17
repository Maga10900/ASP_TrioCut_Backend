using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IServiceRepository
{
    Task<Service> AddAsync(Service service);
    void UpdateAsync(Service service);
    Task<List<Service>> GetAllAsync();
    Task DeleteAsync(Guid serviceId);
    Task<Service> GetByIdAsync(Guid serviceId);
    Task<Service> GetByNameAsync(string serviceName);
}
