using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IWorkerRepository
{
    Task<Worker> AddAsync(Worker worker);
    void Update(Worker worker);
    Task DeleteProfileAsync(Worker worker);
    Task<List<Worker>> GetAllAsync();
    Task<Worker> GetByIdAsync (Guid workerId);
}
