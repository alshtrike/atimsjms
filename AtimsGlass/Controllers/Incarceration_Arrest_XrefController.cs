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
    public class Incarceration_Arrest_XrefController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/Incarceration_Arrest_Xref
        public IQueryable<Incarceration_Arrest_Xref> GetIncarceration_Arrest_Xref()
        {
            return db.Incarceration_Arrest_Xref;
        }

        // GET: api/Incarceration_Arrest_Xref/5
        [ResponseType(typeof(Incarceration_Arrest_Xref))]
        public IHttpActionResult GetIncarceration_Arrest_Xref(int id)
        {
            Incarceration_Arrest_Xref incarceration_Arrest_Xref = db.Incarceration_Arrest_Xref.Find(id);
            if (incarceration_Arrest_Xref == null)
            {
                return NotFound();
            }

            return Ok(incarceration_Arrest_Xref);
        }

        // PUT: api/Incarceration_Arrest_Xref/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncarceration_Arrest_Xref(int id, Incarceration_Arrest_Xref incarceration_Arrest_Xref)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incarceration_Arrest_Xref.Incarceration_arrest_xref_id)
            {
                return BadRequest();
            }

            db.Entry(incarceration_Arrest_Xref).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Incarceration_Arrest_XrefExists(id))
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

        // POST: api/Incarceration_Arrest_Xref
        [ResponseType(typeof(Incarceration_Arrest_Xref))]
        public IHttpActionResult PostIncarceration_Arrest_Xref(Incarceration_Arrest_Xref incarceration_Arrest_Xref)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incarceration_Arrest_Xref.Add(incarceration_Arrest_Xref);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Incarceration_Arrest_XrefExists(incarceration_Arrest_Xref.Incarceration_arrest_xref_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = incarceration_Arrest_Xref.Incarceration_arrest_xref_id }, incarceration_Arrest_Xref);
        }

        // DELETE: api/Incarceration_Arrest_Xref/5
        [ResponseType(typeof(Incarceration_Arrest_Xref))]
        public IHttpActionResult DeleteIncarceration_Arrest_Xref(int id)
        {
            Incarceration_Arrest_Xref incarceration_Arrest_Xref = db.Incarceration_Arrest_Xref.Find(id);
            if (incarceration_Arrest_Xref == null)
            {
                return NotFound();
            }

            db.Incarceration_Arrest_Xref.Remove(incarceration_Arrest_Xref);
            db.SaveChanges();

            return Ok(incarceration_Arrest_Xref);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Incarceration_Arrest_XrefExists(int id)
        {
            return db.Incarceration_Arrest_Xref.Count(e => e.Incarceration_arrest_xref_id == id) > 0;
        }
    }
}