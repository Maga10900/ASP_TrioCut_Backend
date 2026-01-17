using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface ICustomerRepository
{
    Task<Customer> AddAsync(Customer customer);
    void Update(Customer customer);
    Task<List<Customer>> GetAllAsync();
    Task DeleteAsync(Customer customer);
    Task<Customer> GetByIdAsync(Guid customerId);
    Task<Customer> GetByEmailAsync(string email);
}
