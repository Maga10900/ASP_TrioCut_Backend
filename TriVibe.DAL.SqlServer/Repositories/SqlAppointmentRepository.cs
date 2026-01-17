using Microsoft.EntityFrameworkCore;
using TriVibe.Common.Exceptions;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlAppointmentRepository : SqlBaseRepository, IAppointmentRepository
{
    public SqlAppointmentRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Appointment> AddAsync(Appointment app)
    {
        await _context.Appointments.AddAsync(app);
        await _context.SaveChangesAsync();
        return app;
    }

    public async Task DeleteAsync(Appointment app)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(b => b.Id == app.Id);
        if(appointment is null)
            return;
        appointment.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Appointment>> GetAllAsync()
    {
        return await _context.Appointments.Where(b => b.IsDeleted == false).ToListAsync();
    }

    public async Task<List<Appointment>> GetByBarberEmailAsync(string barberEmail)
    {
        return await _context.Appointments.Where(b => b.BarberEmail == barberEmail && b.IsDeleted == false).ToListAsync();

    }

    public async Task<List<Appointment>> GetByCustomerEmailAsync(string customerEmail)
    {
        return await _context.Appointments.Where(b => b.CustomerEmail == customerEmail && b.IsDeleted == false).ToListAsync();
    }

    public async Task<Appointment> GetByIdAsync(Guid appId)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(b => b.Id == appId && b.IsDeleted == false);

        if(appointment is null)
            throw new NotFoundException("Appointment is not found");
        return appointment;
    }

    public async Task Update(Appointment appointment)
    {
        var existing = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointment.Id && !a.IsDeleted) ?? throw new Exception();
        _context.Appointments.Update(appointment);
    }

}
