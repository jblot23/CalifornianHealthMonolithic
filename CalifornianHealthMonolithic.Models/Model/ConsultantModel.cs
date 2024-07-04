using CalifornianHealthMonolithic.DTO.Consultant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalifornianHealthMonolithic.Models
{
    public class ConsultantModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Speciality { get; set; }
    }

    public class ConsultantModelList
    {
        public List<ConsultantCalendar> ConsultantCalendars { get; set; }
        public List<ConsultantDto> Consultants { get; set; }
        public int SelectedConsultantId { get; set; }
        public SelectList ConsultantsList { get; set; }
        public int[] ConsultantDatesAvaliable { get; set; }
    }

}