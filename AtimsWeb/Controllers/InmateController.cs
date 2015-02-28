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
using AtimsWeb.ViewModels;

namespace AtimsWeb.Controllers
{
    public class InmateController : ApiController
    {
        private readonly JMS db = new JMS();

        // HTTP GET ~/api/Inmates/4
        // Using a parameter returns a set of inmates 
       
        [ResponseType(typeof(InmateVM))]
        public IHttpActionResult GetInmates(int id)
        {
            IQueryable<InmateVM> moduleList =
   
                from mod in db.Inmates
                where mod.inmate_id == id
                orderby mod.inmate_id
                select new InmateVM()
                {
                    inmate_number = mod.inmate_number,
                    inmate_received_date = mod.inmate_received_date,
                    inmate_status = mod.inmate_status,
                    inmate_scheduled_release_date = mod.inmate_scheduled_release_date,
                    inmate_personal_inventory = mod.inmate_personal_inventory,
                    inmate_balance = mod.inmate_balance,
                    inmate_deposited_balance = mod.inmate_deposited_balance,
                    inmate_debt = mod.inmate_debt,
                    inmate_medical_flags = mod.inmate_medical_flags,
                    inmate_class_flags = mod.inmate_class_flags,
                    inmate_active = mod.inmate_active
                };
            return Ok(moduleList);
        }
    }
}
