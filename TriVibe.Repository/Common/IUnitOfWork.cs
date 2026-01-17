using TriVibe.Repository.Repositories;

namespace TriVibe.Repository.Common;

public interface IUnitOfWork
{
    public IUserRepository Users { get;  }
    public IBarberRepository Barbers { get; }
    public ICustomerRepository Customers { get; }
    public IServiceRepository Services { get; }
    public IAppointmentRepository Appointments { get; }
    public IReviewRepository Reviews { get; }
    public Task SaveChangesAsync();
}
