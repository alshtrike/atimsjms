using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AtimsWeb.Models;
using AtimsWeb.ViewModels;

namespace AtimsWeb.Controllers {

    public class InmatesController : ApiController {
        private JMS db = new JMS();

        // Returns all active inmates
        [Route("api/Inmates")]
        public IHttpActionResult GetActiveInmates() {
            IQueryable<Inmate> inmateQuery =
                from inmate in db.Inmate
                where inmate.inmate_active == 1
                select inmate;

            return Ok(buildInmateVM(inmateQuery));
        }

        // buildInmatesVM is separate from GetActiveInmates to allow creating
        //   multiple search api methods such as by facility or by sending a
        //   list of inmate_id's. The SQL query isn't made until the ToList( )
        //   function is called, so this is still efficient.
        private List<InmateVM> buildInmateVM(IQueryable<Inmate> inmateQuery) {
            List<InmateVM> inmateList =
                inmateQuery.Select(inmate => new InmateVM() {
                    Id = inmate.inmate_id,
                    Number = inmate.inmate_number,
                    FirstName = inmate.Person.person_first_name,
                    MiddleName = inmate.Person.person_middle_name,
                    LastName = inmate.Person.person_last_name,
                    FacilityName = inmate.Facility.Facility_Name,
                    Recieved = inmate.inmate_received_date,
                    Release = inmate.inmate_scheduled_release_date,
                    Status = inmate.inmate_status,
                }).ToList();
            return inmateList;
        }

    }
}