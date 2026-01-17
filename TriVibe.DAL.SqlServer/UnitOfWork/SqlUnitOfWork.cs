using Microsoft.Extensions.Configuration;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.DAL.SqlServer.Repositories;
using TriVibe.Repository.Common;
using TriVibe.Repository.Repositories;
namespace TriVibe.DAL.SqlServer.UnitOfWork;

public class SqlUnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private readonly TrioCutDb _context;

    public SqlUnitOfWork(IConfiguration configuratin, TrioCutDb context)
    {
        _connectionString = configuratin.GetConnectionString("DefaultConnection");
        _context = context;
    }

    public SqlUserRepository _userRepository;
    public SqlBarberRepository _barberRepository;
    public SqlCustomerRepository _customerRepository;
    public SqlServiceRepository _serviceRepository;
    public SqlAppointmentRepository _appointmentRepository;
    public SqlReviewRepository _reviewRepository;

    public IUserRepository Users => _userRepository ??= new SqlUserRepository(_connectionString, _context);
	public IBarberRepository Barbers => _barberRepository ??= new SqlBarberRepository(_connectionString, _context);
    public ICustomerRepository Customers => _customerRepository ??= new SqlCustomerRepository(_connectionString, _context);
    public IServiceRepository Services => _serviceRepository ??= new SqlServiceRepository(_connectionString, _context);
    public IAppointmentRepository Appointments => _appointmentRepository ??= new SqlAppointmentRepository(_connectionString, _context);
    public IReviewRepository Reviews => _reviewRepository ??= new SqlReviewRepository(_connectionString, _context);

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
