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
    public class InmatesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Inmates
        public IQueryable<Inmate> GetInmates()
        {
            return db.Inmates;
        }

        // GET: api/Inmates/5
        [ResponseType(typeof(Inmate))]
        public async Task<IHttpActionResult> GetInmate(int id)
        {
            Inmate inmate = await db.Inmates.FindAsync(id);
            if (inmate == null)
            {
                return NotFound();
            }

            return Ok(inmate);
        }

        // PUT: api/Inmates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInmate(int id, Inmate inmate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inmate.InmateId)
            {
                return BadRequest();
            }

            db.Entry(inmate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostInmate(Inmate inmate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inmates.Add(inmate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inmate.InmateId }, inmate);
        }

        // DELETE: api/Inmates/5
        [ResponseType(typeof(Inmate))]
        public async Task<IHttpActionResult> DeleteInmate(int id)
        {
            Inmate inmate = await db.Inmates.FindAsync(id);
            if (inmate == null)
            {
                return NotFound();
            }

            db.Inmates.Remove(inmate);
            await db.SaveChangesAsync();

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
            return db.Inmates.Count(e => e.InmateId == id) > 0;
        }
    }
}