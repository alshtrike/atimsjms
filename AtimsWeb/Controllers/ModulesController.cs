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
using AtimsWeb.Models;

namespace AtimsWeb.Controllers
{
    // @TODO: Ask Client if visible modules should be checked here or in angular
    // @TODO: Implement access control when Users are implemented
    // @TODO: Implement license checking
    // @TODO: Implement 500 Error in the event the database is unreachable (Exception occured 2015/02/06)
    public class ModulesController : ApiController
    {
        private JMS db = new JMS();

        // HTTP GET ~/api/Modules/4
        // Using a parameter returns a set of modules based on which App is being
        //   selected (AppAO_id)
        [ResponseType(typeof(AppAO_Module))]
        public IHttpActionResult GetModules(int id)
        {
            IQueryable<AppAO_Module> moduleList = db.AppAO_Module
                .Where(mod => mod.AppAO_id == id)
                .OrderBy( mod => mod.AppAO_Module_order );

            return Ok(moduleList);
        }
         
    }
}