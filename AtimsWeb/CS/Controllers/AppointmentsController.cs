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

namespace AtimsWeb.Controllers {

    // @TODO: Class Primarily Auto Generated - Clean this up

    public class AppointmentsController : ApiController {

        private JMS db = new JMS();

        // GET: api/Appointments
        [Route("api/Appointments")]
        public IHttpActionResult GetAppointments()
        {
            IQueryable<AppointmentsVM> appointmentsList =
                from appt in db.Appointments
                orderby appt.appointment_date
                select new AppointmentsVM() {
                    Date = appt.appointment_date,
                    Duration = appt.appointment_duration,
                    Notes = appt.appointment_notes,
                    Place = appt.appointment_place,
                    Reason = appt.appointment_reason,
                    Time = appt.appointment_time
                };

            return Ok(appointmentsList);
        }

        // GET: api/Appointments/5
        [ResponseType(typeof(AppointmentsVM))]
        public IHttpActionResult GetAppointment(int arg) {
            IQueryable<AppointmentsVM> appointmentsList =
                from appt in db.Appointments
                orderby appt.appointment_date
                select new AppointmentsVM() {
                    Date = appt.appointment_date,
                    Duration = appt.appointment_duration,
                    Notes = appt.appointment_notes,
                    Place = appt.appointment_place,
                    Reason = appt.appointment_reason,
                    Time = appt.appointment_time
                };

            return Ok(appointmentsList);
        }

        // PUT: api/Appointments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointment(int id, Appointment appointment){

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != appointment.appointment_id) {
                return BadRequest();
            }

            db.Entry(appointment).State = EntityState.Modified;

            try {
                db.SaveChanges();
            } catch (DbUpdateConcurrencyException) {
                if (!AppointmentExists(id)) {
                    return NotFound();
                }else{
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Appointments
        [Route("api/Appointments")]
        [HttpPost]
       [ResponseType(typeof(Appointment))]
        public void PostAppointment(AppointmentsVM appointmentVM) {
            if (!ModelState.IsValid)
            {
           //     return BadRequest(ModelState);
            }
           Appointment appointment = new Appointment();
            appointment.appointment_reason = appointmentVM.Reason;
            appointment.appointment_date = DateTime.Parse(appointmentVM.Time);
            appointment.appointment_notes = appointmentVM.Notes;
            appointment.appointment_duration = appointmentVM.Duration;
            appointment.appointment_id = 0;
            db.Appointments.Add(appointment);
            db.SaveChanges();
             //   return CreatedAtRoute("DefaultApi", new { id = appointment.appointment_id }, appointment);
        }

        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult DeleteAppointment(int id) {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null) {
                return NotFound();
            }

            db.Appointments.Remove(appointment);
            db.SaveChanges();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentExists(int id) {
            return db.Appointments.Count(e => e.appointment_id == id) > 0;
        }
    }
}