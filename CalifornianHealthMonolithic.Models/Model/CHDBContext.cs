using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CalifornianHealthMonolithic.Models
{
    public class CHDBContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Consultant> Consultants { get; set; }

        public DbSet<ConsultantCalendar> ConsultantCalendars { get; set; }

        public DbSet<Patient> Patients { get; set; }

    }
   

}