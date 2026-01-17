using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IReviewRepository
{
    Task<Review> AddAsync(Review review);
    Task DeleteAsync(Review review);
    Task<List<Review>> GetAllAsync();
    Task<Review> GetByIdAsync(Guid id);
    Task Update(Review review);
}
