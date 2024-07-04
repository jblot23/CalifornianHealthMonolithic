using CalifornianHealthMonolithic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealthMonolithic.Services
{
    public class AppointmentRepository
    {
        private readonly CHDBContext _context;

        public AppointmentRepository(CHDBContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task AddAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }

}
