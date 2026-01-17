using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface IUserRepository
{
    Task RegisterAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}
