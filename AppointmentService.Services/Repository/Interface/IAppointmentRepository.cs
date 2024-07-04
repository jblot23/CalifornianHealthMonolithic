using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealthMonolithic.Repository.Interface
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(int id);
        Task<List<Appointment>> GetAllAsync();
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Appointment appointment);
    }
}
