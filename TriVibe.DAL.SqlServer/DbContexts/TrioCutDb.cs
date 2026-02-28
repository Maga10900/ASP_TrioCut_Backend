using Microsoft.EntityFrameworkCore;

using TriVibe.Domain.Entities.Concretes;

namespace TriVibe.DAL.SqlServer.DbContexts;

public class TrioCutDb : DbContext
{
	public TrioCutDb(DbContextOptions<TrioCutDb> options) : base(options) { }
	public DbSet<Barber> Barbers { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Service> Services { get; set; }
	public DbSet<Admin> Admins { get; set; }
	public DbSet<Appointment> Appointments { get; set; }
	public DbSet<Review> Reviews { get; set; }
	public DbSet<Worker> Workers { get; set; }
	public DbSet<Client> Clients { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Notification> Notifications { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>()
            .HasOne(w => w.Client)
            .WithMany(c => c.Workers)
            .HasForeignKey(w => w.ClientId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Worker)
            .WithMany(w => w.Orders)
            .HasForeignKey(o => o.WorkerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.Worker)
            .WithMany() // Assuming Worker doesn't have a List<Notification> property, or add it if needed
            .HasForeignKey(n => n.WorkerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasIndex(a => new { a.BarberEmail, a.AppointmentDate })
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Barber)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BarberId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Worker)
            .WithMany(w => w.Reviews)
            .HasForeignKey(r => r.WorkerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Client)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
