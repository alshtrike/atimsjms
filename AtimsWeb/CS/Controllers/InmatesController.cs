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
                    Age= inmate.Person.person_age,
                    Dob = inmate.Person.person_dob,
                    FacilityName = inmate.Facility.Facility_Name,
                    Recieved = inmate.inmate_received_date,
                    Release = inmate.inmate_scheduled_release_date,
                    Status = inmate.inmate_status,
                }).ToList();
            return inmateList;
        }

        // POST: api/Inmates
        [Route("api/Inmates")]
        [HttpPost]
        [ResponseType(typeof(Inmate))]
        public IHttpActionResult PostInmate(InmateVM inmateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            Person person = new Person();
            person.person_age = inmateVM.Age;
            person.person_first_name = inmateVM.FirstName;
            person.person_last_name = inmateVM.LastName;
            person.person_middle_name = inmateVM.MiddleName;
            person.person_dob = inmateVM.Dob;
            person.person_id = 0;
            db.Person.Add(person);
            

            Inmate inmate = new Inmate();
            inmate.inmate_number = inmateVM.Number;
            inmate.inmate_received_date = inmateVM.Recieved;
            inmate.inmate_scheduled_release_date = inmateVM.Release;
            inmate.inmate_status = inmateVM.Status;

            inmate.person_id = person.person_id;

            var query = from f in db.Facility where f.Facility_Name.Equals(inmateVM.FacilityName) select f.Facility_id;
            inmate.Facility_id = query.FirstOrDefault();

            inmate.inmate_id = 0;
            db.Inmate.Add(inmate);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { controller = "person", id = inmate.inmate_id }, inmate);
        }

    }
}