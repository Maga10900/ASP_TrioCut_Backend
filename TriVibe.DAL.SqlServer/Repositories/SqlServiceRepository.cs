using Microsoft.EntityFrameworkCore;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlServiceRepository : SqlBaseRepository, IServiceRepository
{
    public SqlServiceRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Service> AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task DeleteAsync(Guid serviceId)
    {
        var serv = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);
        if (serv == null)
            return;
        serv.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public Task<List<Service>> GetAllAsync()
    {
        var services = _context.Services.Where(s => s.IsDeleted == false).ToListAsync();
        return services;
    }

    public async Task<Service> GetByIdAsync(Guid serviceId)
    {
        var serv = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId && s.IsDeleted == false);
        if(serv == null)
            return null;
        return serv;
    }

    public async Task<Service> GetByNameAsync(string serviceName)
    {
        var serv = await _context.Services.FirstOrDefaultAsync(s => s.Name == serviceName);
        if (serv is null)
            return null;
        return serv;
    }

    public void UpdateAsync(Service service)
    {
		var existingService= _context.Services.FirstOrDefault(c => c.Id == service.Id && !c.IsDeleted) ?? throw new Exception();
		_context.Services.Update(existingService);
	}
}
