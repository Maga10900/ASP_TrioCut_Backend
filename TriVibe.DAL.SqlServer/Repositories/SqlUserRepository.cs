using Microsoft.EntityFrameworkCore;

using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;
namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlUserRepository : SqlBaseRepository, IUserRepository
{
	public SqlUserRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
	{

	}

	public async Task<User?> GetByEmailAsync(string email)
	{
		var user = await _context.Customers.FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);
		var user2 = await _context.Barbers.FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);
		var user3 = await _context.Admins.FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);
		var user4 = await _context.Workers.FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);
		var user5 = await _context.Clients.FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);
		if (user == null)
		{
			if (user2 == null)
			{
				if (user3 == null)
				{
					if (user4 == null)
					{
						if (user5 == null)
						{
							return null;
						}
						else return user5;
					}
					else return user4;
				}
				else return user3;
			}

			else return user2;
		}
		else return user;
	}

	public async Task RegisterAsync(User user)
	{
		if (user is Customer customer)
		{
			await _context.Customers.AddAsync(customer);
		}
		else if (user is Barber barber)
		{
			await _context.Barbers.AddAsync(barber);
		}
		else if (user is Admin admin)
		{
			await _context.Admins.AddAsync(admin);
		}
		else if (user is Worker worker)
		{
			await _context.Workers.AddAsync(worker);
		}
		else if (user is Client client)
		{
			await _context.Clients.AddAsync(client);
		}
		else 
		{
			throw new ArgumentException("Unknown user type", nameof(user));
		}
		
		await _context.SaveChangesAsync();
	}
}
