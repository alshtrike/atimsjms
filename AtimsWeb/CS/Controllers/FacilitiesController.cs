using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AtimsWeb.Models;
using AtimsWeb.ViewModels;
namespace AtimsWeb.CS.Controllers
{
    public class FacilitiesController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/Facilities
        [Route("api/Facilities")]
        public IHttpActionResult GetAppointments()
        {
            IQueryable<FacilitiesVM> facilitiesList =
                from fac in db.Facility
                orderby fac.Facility_Name
                select new FacilitiesVM()
                {
                    FacilityName = fac.Facility_Name
                };

            return Ok(facilitiesList);
        }
    }
}
