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
    public class ClientController : Controller
    {
        private myContext db = new myContext();

        // GET: Client
        public ActionResult Index()
        {
            var clientModels = db.ClientModels.Include(c => c.DocumentType);
            return View(clientModels.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientModel = db.ClientModels.Find(id);
            if (clientModel == null)
            {
                return HttpNotFound();
            }
            return View(clientModel);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType");
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,ID,PersonModelID,UserName,FirstName,LastName,Email,CompareEmail,CellPhoneNumber,DateOfBirth,DocumentNumber")] ClientModel clientModel)
        {
            if (ModelState.IsValid)
            {
                db.ClientModels.Add(clientModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType", clientModel.ID);
            return View(clientModel);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientModel = db.ClientModels.Find(id);
            if (clientModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType", clientModel.ID);
            return View(clientModel);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,ID,PersonModelID,UserName,FirstName,LastName,Email,CompareEmail,CellPhoneNumber,DateOfBirth,DocumentNumber")] ClientModel clientModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.DocumentTypeModels, "ID", "DocumentType", clientModel.ID);
            return View(clientModel);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientModel = db.ClientModels.Find(id);
            if (clientModel == null)
            {
                return HttpNotFound();
            }
            return View(clientModel);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientModel clientModel = db.ClientModels.Find(id);
            db.ClientModels.Remove(clientModel);
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
