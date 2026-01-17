using Microsoft.EntityFrameworkCore;
using TriVibe.Common.Exceptions;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlReviewRepository : SqlBaseRepository, IReviewRepository
{
    public SqlReviewRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Review> AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task DeleteAsync(Review review)
    {
        var rev = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == review.Id);
        if (rev == null) return;
        rev.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Review>> GetAllAsync()
    {
        return await _context.Reviews.Where(r => !r.IsDeleted).ToListAsync();
    }

    public async Task<Review> GetByIdAsync(Guid id)
    {
        var rev = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        if (rev == null) throw new NotFoundException("Review not found");
        return rev;
    }

    public async Task Update(Review review)
    {
        var existing = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == review.Id && !r.IsDeleted) ?? throw new Exception();
        _context.Reviews.Update(review);
    }
}
