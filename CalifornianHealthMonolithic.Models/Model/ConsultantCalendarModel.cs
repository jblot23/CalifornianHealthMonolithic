using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealthMonolithic.Models
{
    public class ConsultantCalendarModel
    {
        public int Id { get; set; }
        public string ConsultantName { get; set; }

        public List<DateTime> AvailableDates { get; set; }
    }
}