using Microsoft.EntityFrameworkCore;
using TriVibe.Common.Exceptions;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlWorkerRepository : SqlBaseRepository, IWorkerRepository
{
    public SqlWorkerRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Worker> AddAsync(Worker worker)
    {
        await _context.Workers.AddAsync(worker);
        await _context.SaveChangesAsync();
        return worker;
    }

    public async Task DeleteProfileAsync(Worker worker)
    {
        var wrk = await _context.Workers.FirstOrDefaultAsync(w => w.Id == worker.Id);
        if (wrk is null)
            return;
        wrk.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Worker>> GetAllAsync()
    {
        return await _context.Workers.Where(w => w.IsDeleted == false).ToListAsync();
    }

    public async Task<Worker> GetByIdAsync(Guid workerId)
    {
        var wrk = await _context.Workers.FirstOrDefaultAsync(w => w.Id == workerId && w.IsDeleted == false);
        if (wrk is null)
            throw new NotFoundException("Worker is not found");
        return wrk;
    }

    public void Update(Worker worker)
    {
        var existingWorker = _context.Workers.FirstOrDefault(w => w.Id == worker.Id && !w.IsDeleted);
        if (existingWorker == null)
            throw new NotFoundException("Worker is not found");
        
        _context.Workers.Update(worker);
    }
}
