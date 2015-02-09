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
    public class ArrestsController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/Arrests
        public IQueryable<Arrest> GetArrests()
        {
            return db.Arrests;
        }

        // GET: api/Arrests/5
        [ResponseType(typeof(Arrest))]
        public IHttpActionResult GetArrest(int id)
        {
            Arrest arrest = db.Arrests.Find(id);
            if (arrest == null)
            {
                return NotFound();
            }

            return Ok(arrest);
        }

        // PUT: api/Arrests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArrest(int id, Arrest arrest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arrest.arrest_id)
            {
                return BadRequest();
            }

            db.Entry(arrest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrestExists(id))
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

        // POST: api/Arrests
        [ResponseType(typeof(Arrest))]
        public IHttpActionResult PostArrest(Arrest arrest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Arrests.Add(arrest);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ArrestExists(arrest.arrest_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = arrest.arrest_id }, arrest);
        }

        // DELETE: api/Arrests/5
        [ResponseType(typeof(Arrest))]
        public IHttpActionResult DeleteArrest(int id)
        {
            Arrest arrest = db.Arrests.Find(id);
            if (arrest == null)
            {
                return NotFound();
            }

            db.Arrests.Remove(arrest);
            db.SaveChanges();

            return Ok(arrest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArrestExists(int id)
        {
            return db.Arrests.Count(e => e.arrest_id == id) > 0;
        }
    }
}