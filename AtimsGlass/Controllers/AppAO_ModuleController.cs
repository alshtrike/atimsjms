﻿using System;
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
    public class AppAO_ModuleController : ApiController
    {
        private JMS db = new JMS();

        // GET: api/AppAO_Module
        public IQueryable<AppAO_Module> GetAppAO_Module()
        {
            return db.AppAO_Module;
        }

        // GET: api/AppAO_Module/5
        [ResponseType(typeof(AppAO_Module))]
        public IHttpActionResult GetAppAO_Module(int id)
        {
            AppAO_Module appAO_Module = db.AppAO_Module.Find(id);
            if (appAO_Module == null)
            {
                return NotFound();
            }

            return Ok(appAO_Module);
        }

        // PUT: api/AppAO_Module/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppAO_Module(int id, AppAO_Module appAO_Module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appAO_Module.AppAO_Module_id)
            {
                return BadRequest();
            }

            db.Entry(appAO_Module).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppAO_ModuleExists(id))
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

        // POST: api/AppAO_Module
        [ResponseType(typeof(AppAO_Module))]
        public IHttpActionResult PostAppAO_Module(AppAO_Module appAO_Module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppAO_Module.Add(appAO_Module);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AppAO_ModuleExists(appAO_Module.AppAO_Module_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = appAO_Module.AppAO_Module_id }, appAO_Module);
        }

        // DELETE: api/AppAO_Module/5
        [ResponseType(typeof(AppAO_Module))]
        public IHttpActionResult DeleteAppAO_Module(int id)
        {
            AppAO_Module appAO_Module = db.AppAO_Module.Find(id);
            if (appAO_Module == null)
            {
                return NotFound();
            }

            db.AppAO_Module.Remove(appAO_Module);
            db.SaveChanges();

            return Ok(appAO_Module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppAO_ModuleExists(int id)
        {
            return db.AppAO_Module.Count(e => e.AppAO_Module_id == id) > 0;
        }
    }
}