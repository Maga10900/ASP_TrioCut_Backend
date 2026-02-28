using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.Repository.Repositories;

public interface INotificationRepository
{
    Task<Notification> AddAsync(Notification notification);
    void Update(Notification notification);
    Task DeleteAsync(Notification notification);
    Task<List<Notification>> GetAllAsync();
    Task<Notification> GetByIdAsync(Guid notificationId);
}
