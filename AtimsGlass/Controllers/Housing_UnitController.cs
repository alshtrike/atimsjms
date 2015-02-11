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
    public class Housing_UnitController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/Housing_Unit
        public IQueryable<Housing_Unit> GetHousing_Unit()
        {
            return db.Housing_Unit;
        }

        // GET: api/Housing_Unit/5
        [ResponseType(typeof(Housing_Unit))]
        public IHttpActionResult GetHousing_Unit(int id)
        {
            Housing_Unit housing_Unit = db.Housing_Unit.Find(id);
            if (housing_Unit == null)
            {
                return NotFound();
            }

            return Ok(housing_Unit);
        }

        // PUT: api/Housing_Unit/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHousing_Unit(int id, Housing_Unit housing_Unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != housing_Unit.Housing_unit_id)
            {
                return BadRequest();
            }

            db.Entry(housing_Unit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Housing_UnitExists(id))
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

        // POST: api/Housing_Unit
        [ResponseType(typeof(Housing_Unit))]
        public IHttpActionResult PostHousing_Unit(Housing_Unit housing_Unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Housing_Unit.Add(housing_Unit);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Housing_UnitExists(housing_Unit.Housing_unit_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = housing_Unit.Housing_unit_id }, housing_Unit);
        }

        // DELETE: api/Housing_Unit/5
        [ResponseType(typeof(Housing_Unit))]
        public IHttpActionResult DeleteHousing_Unit(int id)
        {
            Housing_Unit housing_Unit = db.Housing_Unit.Find(id);
            if (housing_Unit == null)
            {
                return NotFound();
            }

            db.Housing_Unit.Remove(housing_Unit);
            db.SaveChanges();

            return Ok(housing_Unit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Housing_UnitExists(int id)
        {
            return db.Housing_Unit.Count(e => e.Housing_unit_id == id) > 0;
        }
    }
}