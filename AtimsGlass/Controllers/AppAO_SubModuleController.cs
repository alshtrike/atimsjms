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
    public class AppAO_SubModuleController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/AppAO_SubModule
        public IQueryable<AppAO_SubModule> GetAppAO_SubModule()
        {
            return db.AppAO_SubModule;
            //return db.AppAO_SubModule.Where(b => b.AppAO_Module_id < 500 && b.AppAO_Module_id>400);
        }

        // GET: api/AppAO_SubModule/5
        [ResponseType(typeof(AppAO_SubModule))]
        public IHttpActionResult GetAppAO_SubModule(int id)
        {
            IQueryable<AppAO_SubModule> appAO_SubModule = db.AppAO_SubModule.Where(b => b.AppAO_Module.AppAO_id == id);
            // AppAO_SubModule appAO_SubModule = db.AppAO_SubModule.Find(id);
            if (appAO_SubModule == null)
            {
                return NotFound();
            }

            return Ok(appAO_SubModule);
        }


        /*~* /
        // Changing and Deleting AppAO_SubModule Objects
        //   This code (PutAppAO_SubModule(), PutAppAO_SubModule(id), DeleteAppAO_SubModule(id)
        //   allows changing subModules from an external API. This behavior is not something we
        //   want at the moment, but it's here just in case. This code being removed will not
        //   interfere with C# code from saving AppAO_Module objects, it will only stop
        //   external WebAPI calls from changing them. 
        
        // PUT: api/AppAO_SubModule/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppAO_SubModule(int id, AppAO_SubModule appAO_SubModule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appAO_SubModule.AppAO_SubModule_id)
            {
                return BadRequest();
            }

            db.Entry(appAO_SubModule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppAO_SubModuleExists(id))
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

        // POST: api/AppAO_SubModule
        [ResponseType(typeof(AppAO_SubModule))]
        public IHttpActionResult PostAppAO_SubModule(AppAO_SubModule appAO_SubModule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppAO_SubModule.Add(appAO_SubModule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AppAO_SubModuleExists(appAO_SubModule.AppAO_SubModule_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = appAO_SubModule.AppAO_SubModule_id }, appAO_SubModule);
        }

        // DELETE: api/AppAO_SubModule/5
        [ResponseType(typeof(AppAO_SubModule))]
        public IHttpActionResult DeleteAppAO_SubModule(int id)
        {
            AppAO_SubModule appAO_SubModule = db.AppAO_SubModule.Find(id);
            if (appAO_SubModule == null)
            {
                return NotFound();
            }

            db.AppAO_SubModule.Remove(appAO_SubModule);
            db.SaveChanges();

            return Ok(appAO_SubModule);
        }
        
        // End Changing and Deleting AppAO_SubModule Objects
        /*~*/


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppAO_SubModuleExists(int id)
        {
            return db.AppAO_SubModule.Count(e => e.AppAO_SubModule_id == id) > 0;
        }
    }
}