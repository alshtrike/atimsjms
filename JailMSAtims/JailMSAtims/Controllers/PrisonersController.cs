using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JailMSAtims.Models;

namespace JailMSAtims.Controllers
{
    public class PrisonersController : Controller
    {
        private PrisonerDBContext db = new PrisonerDBContext();

        // GET: Prisoners
        public ActionResult Index()
        {
            return View(db.Prisoners.ToList());
        }

        // GET: Prisoners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisoner prisoner = db.Prisoners.Find(id);
            if (prisoner == null)
            {
                return HttpNotFound();
            }
            return View(prisoner);
        }

        // GET: Prisoners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prisoners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Age")] Prisoner prisoner)
        {
            if (ModelState.IsValid)
            {
                db.Prisoners.Add(prisoner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prisoner);
        }

        // GET: Prisoners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisoner prisoner = db.Prisoners.Find(id);
            if (prisoner == null)
            {
                return HttpNotFound();
            }
            return View(prisoner);
        }

        // POST: Prisoners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Age")] Prisoner prisoner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prisoner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prisoner);
        }

        // GET: Prisoners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisoner prisoner = db.Prisoners.Find(id);
            if (prisoner == null)
            {
                return HttpNotFound();
            }
            return View(prisoner);
        }

        // POST: Prisoners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prisoner prisoner = db.Prisoners.Find(id);
            db.Prisoners.Remove(prisoner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
