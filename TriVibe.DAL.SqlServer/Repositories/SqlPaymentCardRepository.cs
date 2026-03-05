using Microsoft.EntityFrameworkCore;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlPaymentCardRepository : SqlBaseRepository, IPaymentCardRepository
{
    public SqlPaymentCardRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task AddAsync(PaymentCard card)
    {
        await _context.PaymentCards.AddAsync(card);
    }

    public async Task<PaymentCard> GetByIdAsync(Guid id)
    {
        var card = await _context.PaymentCards
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        if (card == null)
            throw new Exception($"PaymentCard with Id '{id}' was not found.");
        return card;
    }

    public async Task<List<PaymentCard>> GetByUserIdAsync(Guid userId)
    {
        return await _context.PaymentCards
            .Where(c => c.UserId == userId && !c.IsDeleted)
            .ToListAsync();
    }

    public Task UpdateAsync(PaymentCard card)
    {
        _context.PaymentCards.Update(card);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var card = await _context.PaymentCards.FirstOrDefaultAsync(c => c.Id == id);
        if (card != null)
        {
            _context.PaymentCards.Remove(card);
        }
    }
}
