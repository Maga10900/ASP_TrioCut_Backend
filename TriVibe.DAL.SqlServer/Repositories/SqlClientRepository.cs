using Microsoft.EntityFrameworkCore;
using TriVibe.Common.Exceptions;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlClientRepository : SqlBaseRepository, IClientRepository
{
    public SqlClientRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Client> AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task DeleteProfileAsync(Client client)
    {
        var clt = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
        if (clt is null)
            return;
        clt.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await _context.Clients.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task<Client> GetByIdAsync(Guid clientId)
    {
        var clt = await _context.Clients.FirstOrDefaultAsync(c => c.Id == clientId && c.IsDeleted == false);
        if (clt is null)
            throw new NotFoundException("Client is not found");
        return clt;
    }

    public void Update(Client client)
    {
        var existingClient = _context.Clients.FirstOrDefault(c => c.Id == client.Id && !c.IsDeleted);
        if (existingClient == null)
            throw new NotFoundException("Client is not found");

        _context.Clients.Update(client);
    }
}
