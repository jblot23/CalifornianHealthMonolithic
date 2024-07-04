using CalifornianHealthMonolithic.AppointmentApi.Input;
using CalifornianHealthMonolithic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CalifornianHealthMonolithic.AppointmentApi.Controllers
{
    public class AppointmentController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public IEnumerable<Appointment> GetAllAppointment([FromBody] GetCurrentAppointment input)
        {
            try
            {
                input.selectedDate = input.selectedDate.AddMonths(1);


                CHDBContext context = new CHDBContext();
                var fetchedResults = context.Appointments.Where(x => x.StartDateTime != null).ToList();
                var selectedAppointments = fetchedResults.Where(x =>
                x.StartDateTime.Value.Month == input.selectedDate.Month
                && x.StartDateTime.Value.Year == input.selectedDate.Year
                && x.ConsultantId == input.consultantId).ToList();

                return selectedAppointments;
            }
            catch (Exception ex)
            {

            }

            return new List<Appointment>();
        }

    }
}
