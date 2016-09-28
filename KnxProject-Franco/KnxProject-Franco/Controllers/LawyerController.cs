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
    public class LawyerController : Controller
    {
        private myContext db = new myContext();

        // GET: Lawyer
        public ActionResult Index()
        {
            var lawyerModels = db.LawyerModels.Include(l => l.DocumentType);
            return View(lawyerModels.ToList());
        }

        // GET: Lawyer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerModel lawyerModel = db.LawyerModels.Find(id);
            if (lawyerModel == null)
            {
                return HttpNotFound();
            }
            return View(lawyerModel);
        }

        // GET: Lawyer/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType");
            return View();
        }

        // POST: Lawyer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,ID,PersonModelID,ProfessionalLicense,ContractDate,UserName,Password,FirstName,LastName,Email,CompareEmail,CellPhoneNumber,DateOfBirth,DocumentNumber")] LawyerModel lawyerModel)
        {
            if (ModelState.IsValid)
            {
                db.LawyerModels.Add(lawyerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType", lawyerModel.ID);
            return View(lawyerModel);
        }

        // GET: Lawyer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerModel lawyerModel = db.LawyerModels.Find(id);
            if (lawyerModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType", lawyerModel.ID);
            return View(lawyerModel);
        }

        // POST: Lawyer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,ID,PersonModelID,ProfessionalLicense,ContractDate,UserName,Password,FirstName,LastName,Email,CompareEmail,CellPhoneNumber,DateOfBirth,DocumentNumber")] LawyerModel lawyerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawyerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType", lawyerModel.ID);
            return View(lawyerModel);
        }

        // GET: Lawyer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawyerModel lawyerModel = db.LawyerModels.Find(id);
            if (lawyerModel == null)
            {
                return HttpNotFound();
            }
            return View(lawyerModel);
        }

        // POST: Lawyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LawyerModel lawyerModel = db.LawyerModels.Find(id);
            db.LawyerModels.Remove(lawyerModel);
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
