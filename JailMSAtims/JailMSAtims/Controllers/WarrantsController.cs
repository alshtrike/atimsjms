using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IdentitySample.Models;
using JailMSAtims.Models;

namespace JailMSAtims.Controllers
{
    public class WarrantsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Warrants
        public IQueryable<Warrant> GetWarrants()
        {
            return db.Warrants;
        }

        // GET: api/Warrants/5
        [ResponseType(typeof(Warrant))]
        public async Task<IHttpActionResult> GetWarrant(int id)
        {
            Warrant warrant = await db.Warrants.FindAsync(id);
            if (warrant == null)
            {
                return NotFound();
            }

            return Ok(warrant);
        }

        // PUT: api/Warrants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWarrant(int id, Warrant warrant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != warrant.id)
            {
                return BadRequest();
            }

            db.Entry(warrant).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarrantExists(id))
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

        // POST: api/Warrants
        [ResponseType(typeof(Warrant))]
        public async Task<IHttpActionResult> PostWarrant(Warrant warrant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Warrants.Add(warrant);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = warrant.id }, warrant);
        }

        // DELETE: api/Warrants/5
        [ResponseType(typeof(Warrant))]
        public async Task<IHttpActionResult> DeleteWarrant(int id)
        {
            Warrant warrant = await db.Warrants.FindAsync(id);
            if (warrant == null)
            {
                return NotFound();
            }

            db.Warrants.Remove(warrant);
            await db.SaveChangesAsync();

            return Ok(warrant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WarrantExists(int id)
        {
            return db.Warrants.Count(e => e.id == id) > 0;
        }
    }
}