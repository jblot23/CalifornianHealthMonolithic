using CalifornianHealthMonolithic.AppointmentApi.Input;
using CalifornianHealthMonolithic.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CalifornianHealthMonolithic.AppointmentApi.Controllers
{
    public class HomeController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public bool MarkAppointment([FromBody] MarkConsultantAppointment input)
        {
            try
            {
                CHDBContext context = new CHDBContext();
                int patientId = 0;

                var isAppointmentExsists = context.Appointments.FirstOrDefault(x =>
                x.StartDateTime.Value.Day == input.start.Day 
                && x.StartDateTime.Value.Month == input.start.Month 
                && x.StartDateTime.Value.Year == input.start.Year);
                if (isAppointmentExsists != null)
                    return false;

                
                var patient = context.Patients.FirstOrDefault(x => x.FName == input.Patient.FName);
                if(patient == null) {
                    Patient patientTobeSavd = new Patient();
                    patientTobeSavd.FName = input.Patient.FName;
                    patientTobeSavd.LName = input.Patient.LName;
                    patientTobeSavd.Address1 = input.Patient.Address1;
                    patientTobeSavd.Address2 = input.Patient.Address2;
                    patientTobeSavd.City = input.Patient.City;

                    context.Patients.Add(patientTobeSavd);
                    context.SaveChanges();

                    patientId = patientTobeSavd.ID;
                }
                else
                {
                    patientId = patient.ID;
                }

                
                ConcurrentQueue<Appointment> cq = new ConcurrentQueue<Appointment>();

                cq.Enqueue(new Appointment()
                {
                    ConsultantId = input.consultantid,
                    StartDateTime = input.start,
                    EndDateTime = input.start.AddHours(1),
                    PatientId = patientId,
                });

                Action action = () =>
                {
                    Appointment localValue;
                    while (cq.TryDequeue(out localValue)) 
                    {
                        var result = context.Appointments.Add(localValue);
                        context.SaveChanges();
                    };
                };

                Parallel.Invoke(action, action, action, action);


                return true;
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        
    }
}
