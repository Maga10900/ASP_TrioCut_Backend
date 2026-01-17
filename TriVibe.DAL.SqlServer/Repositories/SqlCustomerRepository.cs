using System.Threading;
using Microsoft.EntityFrameworkCore;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlCustomerRepository : SqlBaseRepository, ICustomerRepository
{
    public SqlCustomerRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task DeleteAsync(Customer customer)
    {
        var cust = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
        if (cust == null)
            return ;
        cust.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public Task<List<Customer>> GetAllAsync()
    {
        return _context.Customers.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task<Customer> GetByEmailAsync(string email)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    public Task<Customer> GetByIdAsync(Guid customerId)
    {
        var cust = _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId && c.IsDeleted == false);
        if(cust == null)
            return null;
        return cust;
    }
    
    public void Update(Customer customer)
    {

        var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == customer.Id && !c.IsDeleted) ?? throw new Exception();
        _context.Customers.Update(existingCustomer);
    }
}
