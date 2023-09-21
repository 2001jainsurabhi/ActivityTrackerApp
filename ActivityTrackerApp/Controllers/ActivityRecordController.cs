using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ActivityTrackerApp.Data;
using ActivityTrackerApp.Models;

namespace ActivityTrackerApp.Controllers
{
    public class ActivityRecordController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ActivityRecord
        public ActionResult Index()
        {
            var activityRecords = db.ActivityRecords.Include(a => a.Person);
            return View(activityRecords.ToList());
        }

        // GET: ActivityRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            if (activityRecord == null)
            {
                return HttpNotFound();
            }
            return View(activityRecord);
        }

        // GET: ActivityRecord/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name");
            return View();
        }

        // POST: ActivityRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Gym,Meditation,MeditationMinutes,Reading,PagesRead,PersonId")] ActivityRecord activityRecord)
        {
            if (ModelState.IsValid)
            {
                db.ActivityRecords.Add(activityRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", activityRecord.PersonId);
            return View(activityRecord);
        }

        // GET: ActivityRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            if (activityRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", activityRecord.PersonId);
            return View(activityRecord);
        }

        // POST: ActivityRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Gym,Meditation,MeditationMinutes,Reading,PagesRead,PersonId")] ActivityRecord activityRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", activityRecord.PersonId);
            return View(activityRecord);
        }

        // GET: ActivityRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            if (activityRecord == null)
            {
                return HttpNotFound();
            }
            return View(activityRecord);
        }

        // POST: ActivityRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            db.ActivityRecords.Remove(activityRecord);
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
