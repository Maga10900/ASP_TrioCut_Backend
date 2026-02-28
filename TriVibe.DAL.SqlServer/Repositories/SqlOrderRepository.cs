using Microsoft.EntityFrameworkCore;
using TriVibe.Common.Exceptions;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlOrderRepository : SqlBaseRepository, IOrderRepository
{
    public SqlOrderRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Order> AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task DeleteAsync(Order order)
    {
        var existing = await _context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
        if (existing is null)
            return;
        existing.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.Where(o => !o.IsDeleted).ToListAsync();
    }

    public async Task<List<Order>> GetByWorkerIdAsync(Guid workerId)
    {
        return await _context.Orders
            .Where(o => o.WorkerId == workerId && !o.IsDeleted)
            .ToListAsync();
    }

    public async Task<Order> GetByIdAsync(Guid orderId)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted);
        if (order is null)
            throw new NotFoundException("Order is not found");
        return order;
    }

    public void Update(Order order)
    {
        var existing = _context.Orders.FirstOrDefault(o => o.Id == order.Id && !o.IsDeleted);
        if (existing is null)
            throw new NotFoundException("Order is not found");
        _context.Orders.Update(order);
    }
}
