using Microsoft.EntityFrameworkCore;
using TriVibe.Common.Exceptions;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlNotificationRepository : SqlBaseRepository, INotificationRepository
{
    public SqlNotificationRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Notification> AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
        return notification;
    }

    public async Task DeleteAsync(Notification notification)
    {
        var existing = await _context.Notifications.FirstOrDefaultAsync(n => n.Id == notification.Id);
        if (existing is null)
            return;
        existing.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Notification>> GetAllAsync()
    {
        return await _context.Notifications.Where(n => !n.IsDeleted).ToListAsync();
    }

    public async Task<Notification> GetByIdAsync(Guid notificationId)
    {
        var notification = await _context.Notifications
            .FirstOrDefaultAsync(n => n.Id == notificationId && !n.IsDeleted);
        if (notification is null)
            throw new NotFoundException("Notification is not found");
        return notification;
    }

    public void Update(Notification notification)
    {
        var existing = _context.Notifications.FirstOrDefault(n => n.Id == notification.Id && !n.IsDeleted);
        if (existing is null)
            throw new NotFoundException("Notification is not found");
        _context.Notifications.Update(notification);
    }
}
