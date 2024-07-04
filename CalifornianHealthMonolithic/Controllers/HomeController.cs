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
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ConsultantModelList conList = new ConsultantModelList();
            CHDBContext dbContext = new CHDBContext();
            Repository repo = new Repository();
            var result = ConsultantClient.FetchConsultant().Result;
            conList.ConsultantsList = new SelectList(result, "Id", "FName");
            conList.Consultants = result;
            return View(conList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}