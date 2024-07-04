using CalifornianHealthMonolithic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealthMonolithic.Code
{
    public class Repository
    {
    
        public List<Consultant> FetchConsultants(CHDBContext dbContext)
        {
            var cons = dbContext.Consultants.ToList();
            return cons;
        }

        public List<ConsultantCalendar> FetchConsultantCalendars(CHDBContext dbContext)
        {
            //Should the consultant detail and the calendar (available dates) be clubbed together?
            //Is this the reason the calendar is slow to load? Rethink how we can rewrite this?



            return dbContext.ConsultantCalendars.ToList();
        }

        public bool CreateAppointment(Appointment model, CHDBContext dbContext)
        {

            var isAppointedAlready = dbContext.Appointments.
                FirstOrDefault(x => x.StartDateTime.Equals(model.StartDateTime));

            if(isAppointedAlready != null)
                return false;

            var appointmentsWithinRange = dbContext.Appointments
            .Where(appointment =>
                    appointment.StartDateTime >= model.StartDateTime &&
                    appointment.EndDateTime <= model.EndDateTime &&
                    appointment.ConsultantId == model.ConsultantId)
                .FirstOrDefault();

            if (appointmentsWithinRange != null)
                return false;


            //Should we double check here before confirming the appointment?
            dbContext.Appointments.Add(model);
            return true;
        }
    }
}