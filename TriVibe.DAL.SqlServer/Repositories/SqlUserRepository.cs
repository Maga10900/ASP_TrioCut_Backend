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
		if (user.UserType == UserType.Customer)
		{
			var customer = new Customer
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
				PhoneNumber = user.PhoneNumber,
				Age = user.Age,
				UserType = user.UserType
			};
			await _context.Customers.AddAsync(customer);
		}
		else if (user.UserType == UserType.Barber)
		{
			var barber = new Barber
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
				PhoneNumber = user.PhoneNumber,
				Age = user.Age,
				UserType = user.UserType
			};
			await _context.Barbers.AddAsync(barber);
		}
		else if (user.UserType == UserType.Admin)
		{
			var admin = new Admin
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
				PhoneNumber = user.PhoneNumber,
				Age = user.Age,
				UserType = user.UserType
			};
			await _context.Admins.AddAsync(admin);
		}
		else if (user.UserType == UserType.Worker)
		{
			var worker = new Worker
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
				PhoneNumber = user.PhoneNumber,
				Age = user.Age,
				UserType = user.UserType
			};
			await _context.Workers.AddAsync(worker);
		}
		else if (user.UserType == UserType.Client)
		{
			var client = new Client
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
				PhoneNumber = user.PhoneNumber,
				Age = user.Age,
				UserType = user.UserType
			};
			await _context.Clients.AddAsync(client);
		}
		await _context.SaveChangesAsync();
	}
}
