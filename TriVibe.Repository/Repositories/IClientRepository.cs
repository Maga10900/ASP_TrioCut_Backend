using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IClientRepository
{
    Task<Client> AddAsync(Client client);
    void Update(Client client);
    Task DeleteProfileAsync(Client client);
    Task<List<Client>> GetAllAsync();
    Task<Client> GetByIdAsync(Guid clientId);
}
