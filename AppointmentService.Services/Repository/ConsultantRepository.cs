using CalifornianHealthMonolithic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealthMonolithic.Services
{

    public class ConsultantRepository
    {
        private readonly CHDBContext _context;

        public ConsultantRepository(CHDBContext context)
        {
            _context = context;
        }

        public async Task<Consultant> GetByIdAsync(int id)
        {
            return await _context.Consultants.FindAsync(id);
        }

        public async Task<List<Consultant>> GetAllAsync()
        {
            return await _context.Consultants.ToListAsync();
        }

        public async Task AddAsync(Consultant consultant)
        {
            _context.Consultants.Add(consultant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Consultant consultant)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Consultant consultant)
        {
            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();
        }
    }
}
