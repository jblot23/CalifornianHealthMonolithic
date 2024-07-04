using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealthMonolithic.AppointmentApi.Input
{
    public class GetCurrentAppointment
    {
        public DateTime selectedDate { get; set; }

        public int consultantId { get; set; }
    }
}