using Microsoft.EntityFrameworkCore;
using TriVibe.Common.Exceptions;
using TriVibe.DAL.SqlServer.DbContexts;
using TriVibe.Domain.Entities.Concretes;
using TriVibe.Repository.Repositories;

namespace TriVibe.DAL.SqlServer.Repositories;

public class SqlBarberRepository : SqlBaseRepository, IBarberRepository
{
    public SqlBarberRepository(string connectionString, TrioCutDb context) : base(connectionString, context)
    {
    }

    public async Task<Barber> AddAsync(Barber barber)
    {
        await _context.Barbers.AddAsync(barber);
        await _context.SaveChangesAsync();
        return barber;
    }

    public async Task DeleteProfileAsync(Barber barber)
    {
        var barb = await _context.Barbers.FirstOrDefaultAsync(b => b.Id == barber.Id);
        if(barb is null)
            return;
        barb.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Barber>> GetAllAsync()
    {
        return await _context.Barbers.Where(b => b.IsDeleted == false).ToListAsync();
    }

    public async Task<Barber> GetByIdAsync(Guid barberId)
    {
        var barb = await _context.Barbers.FirstOrDefaultAsync(b => b.Id == barberId && b.IsDeleted == false);
        if(barb is null)
            throw new NotFoundException("Barber is not found");
        return barb;
    }

    public async Task<List<Customer>> GetAppointments(Guid barberId)
    {
        var appointments = await _context.Customers
            .Where(c => c.BarberId == barberId && !c.IsDeleted)
            .ToListAsync();
        return appointments;
    }

    public void Update(Barber barber)
    {
        var existingBarber = _context.Barbers.FirstOrDefault(c => c.Id == barber.Id && !c.IsDeleted) ?? throw new Exception();
        _context.Barbers.Update(existingBarber);
    }

    public async Task<Appointment> TakeAppointment(Guid appointmentId)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(b => b.Id == appointmentId && !b.IsDeleted);
        if(appointment is null)
            throw new NotFoundException("Appointment is not found");
        appointment.Status = Domain.AppointmentStatus.Confirmed;
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
        return appointment;
    }

    public async Task<Appointment> DeclineAppointment(Guid appointmentId)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(b => b.Id == appointmentId && !b.IsDeleted);
        if(appointment is null)
            throw new NotFoundException("Appointment is not found");
        appointment.Status = Domain.AppointmentStatus.Cancelled;
        appointment.IsDeleted = true;   
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
        return appointment;
    }

}
