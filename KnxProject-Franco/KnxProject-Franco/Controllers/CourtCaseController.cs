using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.Models;

namespace KnxProject_Franco.Controllers
{
    public class CourtCaseController : Controller
    {
        private myContext db = new myContext();

        // GET: CourtCase
        public ActionResult Index()
        {
            if (db.CourtCaseModels.Count() > 0)
            {
                return View(db.CourtCaseModels.ToList());
            }
            return View();
        }

        // GET: CourtCase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseModel courtCaseModel = db.CourtCaseModels.Find(id);
            if (courtCaseModel == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseModel);
        }

        // GET: CourtCase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtCase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClientID,CurrentStatusId,CourtBranchId,LawyerId,StartDate")] CourtCaseModel courtCaseModel)
        {
            if (ModelState.IsValid)
            {
                db.CourtCaseModels.Add(courtCaseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courtCaseModel);
        }

        // GET: CourtCase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseModel courtCaseModel = db.CourtCaseModels.Find(id);
            if (courtCaseModel == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseModel);
        }

        // POST: CourtCase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClientID,CurrentStatusId,CourtBranchId,LawyerId,StartDate")] CourtCaseModel courtCaseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtCaseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtCaseModel);
        }

        // GET: CourtCase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseModel courtCaseModel = db.CourtCaseModels.Find(id);
            if (courtCaseModel == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseModel);
        }

        // POST: CourtCase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtCaseModel courtCaseModel = db.CourtCaseModels.Find(id);
            db.CourtCaseModels.Remove(courtCaseModel);
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
