using CalifornianHealthMonolithic.ApiClient;
using CalifornianHealthMonolithic.Code;
using CalifornianHealthMonolithic.Models;
using CalifornianHealthMonolithic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalifornianHealthMonolithic.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        //TODO: Change this method to display the consultant calendar. Ensure that the user can have a real time view of 
        //the consultant's availability;
        public ActionResult GetConsultantCalendar(int? consultantId)
        {
            ConsultantModelList conList = new ConsultantModelList();
            CHDBContext dbContext = new CHDBContext();
            CalifornianHealthMonolithic.Code.Repository repo = new CalifornianHealthMonolithic.Code.Repository();
            var result = ConsultantClient.FetchConsultant().Result;
            conList.ConsultantsList = new SelectList(result, "Id", "FName", 1);

            conList.Consultants = result;

            if(consultantId != 0)
            {
                var consultantCurrentAvalibilty = dbContext.ConsultantCalendars.Where(c => c.ConsultantId == consultantId
                && c.Available == true
                && c.Date.Value.Year == DateTime.Now.Year
                && c.Date.Value.Month == DateTime.Now.Month
                ).ToList();

                    List<int> dateDays = new List<int>();
                foreach(var avaliabltyDate  in consultantCurrentAvalibilty)
                { 
                    dateDays.Add(avaliabltyDate.Date.Value.Day);
                }


                conList.ConsultantDatesAvaliable = dateDays.ToArray();
            }

            return View(conList);
        }

        //TODO: Change this method to ensure that members do not have to wait endlessly. 
        public ActionResult ConfirmAppointment(Appointment model)
        {
            CHDBContext dbContext = new CHDBContext();

            //Code to create appointment in database
            //This needs to be reassessed. Before confirming the appointment, should we check if the consultant calendar is still available?
            AppointmentService appointmentService = new AppointmentService();
            appointmentService.ConfirmAppointmentAsync(model);

            return View();
        }
    }
}