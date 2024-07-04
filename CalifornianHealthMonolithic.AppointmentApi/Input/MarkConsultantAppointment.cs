using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealthMonolithic.AppointmentApi.Input
{
    public class MarkConsultantAppointment
    {
        public int consultantid { get; set; }

        public DateTime start {get; set;} 
        
        public DateTime end { get; set; }
        
        public Patient Patient { get; set; }
    }
}