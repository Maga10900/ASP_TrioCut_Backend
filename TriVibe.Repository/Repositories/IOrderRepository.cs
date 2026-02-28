using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IOrderRepository
{
    Task<Order> AddAsync(Order order);
    void Update(Order order);
    Task DeleteAsync(Order order);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetByWorkerIdAsync(Guid workerId);
    Task<Order> GetByIdAsync(Guid orderId);
}
