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
using AtimsWeb.Models;
using AtimsWeb.ViewModels;

namespace AtimsWeb.Controllers
{

    // @TODO: Implement access control when Users are implemented
    // @TODO: Implement license checking
    // @TODO: Implement 500 Error in the event the database is unreachable (Exception occured 2015/02/06)
    public class ModulesController : ApiController
    {
        private readonly JMS db = new JMS();

        // Returns a set of modules based on which App is being requested
        [Route("api/Modules/{id}")]
        public IHttpActionResult GetModules(int id) {
            IQueryable<ModulesVM> moduleList = 
                from mod in db.AppAO_Module 
                where mod.AppAO_id == id && mod.AppAO_Module_visible == 1
                orderby mod.AppAO_Module_order
                select new ModulesVM() {
                    Name = mod.AppAO_Module_Name,
                    ToolTip = mod.AppAO_Module_ToolTip,
                    SubModules = mod.AppAO_SubModules
                        .Where(sm => sm.AppAO_SubModule_visible == 1)
                        .OrderBy(sm => sm.AppAO_SubModule_order).
                        Select(sm => new SubModuleVM() {
                            Name = sm.AppAO_SubModule_Name, Usercontrol = sm.AppAO_SubModule_usercontrol,
                            Help = sm.AppAO_SubModule_Help, ToolTip = sm.AppAO_SubModule_ToolTip
                    }).ToList()
                };

            return Ok(moduleList);
        }
         
    }
}