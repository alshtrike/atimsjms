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
    public class IncarcerationsController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/Incarcerations
        public IQueryable<Incarceration> GetIncarcerations()
        {
            return db.Incarcerations;
        }

        // GET: api/Incarcerations/5
        [ResponseType(typeof(Incarceration))]
        public IHttpActionResult GetIncarceration(int id)
        {
            Incarceration incarceration = db.Incarcerations.Find(id);
            if (incarceration == null)
            {
                return NotFound();
            }

            return Ok(incarceration);
        }

        // PUT: api/Incarcerations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncarceration(int id, Incarceration incarceration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incarceration.Incarceration_id)
            {
                return BadRequest();
            }

            db.Entry(incarceration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncarcerationExists(id))
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

        // POST: api/Incarcerations
        [ResponseType(typeof(Incarceration))]
        public IHttpActionResult PostIncarceration(Incarceration incarceration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incarcerations.Add(incarceration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IncarcerationExists(incarceration.Incarceration_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = incarceration.Incarceration_id }, incarceration);
        }

        // DELETE: api/Incarcerations/5
        [ResponseType(typeof(Incarceration))]
        public IHttpActionResult DeleteIncarceration(int id)
        {
            Incarceration incarceration = db.Incarcerations.Find(id);
            if (incarceration == null)
            {
                return NotFound();
            }

            db.Incarcerations.Remove(incarceration);
            db.SaveChanges();

            return Ok(incarceration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncarcerationExists(int id)
        {
            return db.Incarcerations.Count(e => e.Incarceration_id == id) > 0;
        }
    }
}