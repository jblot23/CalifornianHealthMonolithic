using CalifornianHealthMonolithic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CalifornianHealthMonolithic.ConsultantApi.Controllers
{
    public class ConsultantController : ApiController
    {

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpGet]
        public async Task<List<Consultant>> FetchConsultants()
        {
            try
            {
                CHDBContext context = new CHDBContext();
                var result = await context.Consultants.ToListAsync();    
                context.Dispose();
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}