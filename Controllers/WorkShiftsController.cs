using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TidrAppProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace TidrAppProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class WorkShiftsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkShifts
        public ActionResult Index()
        {
            return View(db.WorkShifts.ToList());
        }

        // GET: WorkShifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = db.WorkShifts.Find(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // GET: WorkShifts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkShifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles ="Admin, Worker")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,Date,StartTime,EndTime,TotalTime,OB1,OB2,FirstSickDay,SickDayTime,VAB")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {

                db.WorkShifts.Add(workShift);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
           
            return View(workShift);
        }

        // GET: WorkShifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = db.WorkShifts.Find(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // POST: WorkShifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Description,Date,StartTime,EndTime,TotalTime,OB1,OB2,FirstSickDay,SickDayTime,VAB")] WorkShift workShift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workShift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workShift);
        }

        // GET: WorkShifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkShift workShift = db.WorkShifts.Find(id);
            if (workShift == null)
            {
                return HttpNotFound();
            }
            return View(workShift);
        }

        // POST: WorkShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkShift workShift = db.WorkShifts.Find(id);
            db.WorkShifts.Remove(workShift);
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
