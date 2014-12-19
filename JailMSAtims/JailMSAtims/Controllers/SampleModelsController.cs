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
using JailMSAtims.Models;

namespace JailMSAtims.Controllers
{
    public class SampleModelsController : ApiController
    {
        private JailMSAtimsContext db = new JailMSAtimsContext();

        // GET: api/SampleModels
        public IQueryable<SampleModel> GetSampleModels()
        {
            return db.SampleModels;
        }

        // GET: api/SampleModels/5
        [ResponseType(typeof(SampleModel))]
        public async Task<IHttpActionResult> GetSampleModel(int id)
        {
            SampleModel sampleModel = await db.SampleModels.FindAsync(id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            return Ok(sampleModel);
        }

        // PUT: api/SampleModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSampleModel(int id, SampleModel sampleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sampleModel.id)
            {
                return BadRequest();
            }

            db.Entry(sampleModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleModelExists(id))
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

        // POST: api/SampleModels
        [ResponseType(typeof(SampleModel))]
        public async Task<IHttpActionResult> PostSampleModel(SampleModel sampleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SampleModels.Add(sampleModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sampleModel.id }, sampleModel);
        }

        // DELETE: api/SampleModels/5
        [ResponseType(typeof(SampleModel))]
        public async Task<IHttpActionResult> DeleteSampleModel(int id)
        {
            SampleModel sampleModel = await db.SampleModels.FindAsync(id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            db.SampleModels.Remove(sampleModel);
            await db.SaveChangesAsync();

            return Ok(sampleModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SampleModelExists(int id)
        {
            return db.SampleModels.Count(e => e.id == id) > 0;
        }
    }
}