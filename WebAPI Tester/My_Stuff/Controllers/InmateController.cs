using WebAPI_Tester.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Tester.Controllers
{
    public class InmateController : ApiController
    {
        Inmate[] inmates = new Inmate[]
        {
            new Inmate {    ID = 1,     name="Brian",   DOB=(new DateTime(1986, 1, 28))},
            new Inmate {    ID = 2,     name="Alex",    DOB=(new DateTime(1986, 1, 29))},
            new Inmate {    ID = 10,    name="Hector",  DOB=(new DateTime(1986, 1, 27))},
            new Inmate {    ID = 22,    name="Seth",    DOB=(new DateTime(1986, 1, 26))},
            new Inmate {    ID = 55,    name="Arnold",  DOB=(new DateTime(1986, 1, 25))},
            new Inmate {    ID = 101,   name="Collin",  DOB=(new DateTime(1986, 1, 24))},
            new Inmate {    ID = 110,   name="Garrett", DOB=(new DateTime(1986, 1, 23))}
        };

        public IEnumerable<Inmate> GetAllInmates()
        {
            return inmates;
        }

        public IHttpActionResult GetInmate(int id)
        {
            var inmate = inmates.FirstOrDefault((p) => p.ID == id);
            if (inmate == null)
            {
                return NotFound();
            }
            return Ok(inmate);
        }
    }
}
