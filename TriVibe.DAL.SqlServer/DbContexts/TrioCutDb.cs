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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasIndex(a => new { a.BarberEmail, a.AppointmentDate })
            .IsUnique()
            .HasFilter("[IsDeleted] = 0");

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Barber)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BarberId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
