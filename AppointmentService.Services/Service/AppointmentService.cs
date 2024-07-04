using CalifornianHealthMonolithic.Code;
using CalifornianHealthMonolithic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealthMonolithic.Services
{
    public class AppointmentService
    {
        public async Task<bool> ConfirmAppointmentAsync(Appointment model)
        {
            CHDBContext dbContext = new CHDBContext();
            AppointmentRepository appointmentRepository = new AppointmentRepository(dbContext);
            await appointmentRepository.AddAsync(model);  
            return true;
        }
        

    }
}
