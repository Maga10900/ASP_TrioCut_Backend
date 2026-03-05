using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IPaymentCardRepository
{
    Task AddAsync(PaymentCard card);
    Task<PaymentCard> GetByIdAsync(Guid id);
    Task<List<PaymentCard>> GetByUserIdAsync(Guid userId);
    Task UpdateAsync(PaymentCard card);
    Task DeleteAsync(Guid id);
}
