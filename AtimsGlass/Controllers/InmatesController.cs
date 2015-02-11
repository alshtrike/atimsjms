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
using AtimsGlass.Models;

namespace AtimsGlass.Controllers
{
    public class InmatesController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/Inmates
        public IQueryable<Inmate> GetInmates()
        {
            return db.Inmates;
        }

        // GET: api/Inmates/5
        [ResponseType(typeof(Inmate))]
        public IHttpActionResult GetInmate(int id)
        {
            Inmate inmate = db.Inmates.Find(id);
            if (inmate == null)
            {
                return NotFound();
            }

            return Ok(inmate);
        }

        // PUT: api/Inmates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInmate(int id, Inmate inmate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inmate.inmate_id)
            {
                return BadRequest();
            }

            db.Entry(inmate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InmateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Inmates
        [ResponseType(typeof(Inmate))]
        public IHttpActionResult PostInmate(Inmate inmate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inmates.Add(inmate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InmateExists(inmate.inmate_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inmate.inmate_id }, inmate);
        }

        // DELETE: api/Inmates/5
        [ResponseType(typeof(Inmate))]
        public IHttpActionResult DeleteInmate(int id)
        {
            Inmate inmate = db.Inmates.Find(id);
            if (inmate == null)
            {
                return NotFound();
            }

            db.Inmates.Remove(inmate);
            db.SaveChanges();

            return Ok(inmate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InmateExists(int id)
        {
            return db.Inmates.Count(e => e.inmate_id == id) > 0;
        }
    }
}