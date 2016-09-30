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
            //if (db.LawyerModels.Count() > 0)
            //{
            //    var lawyerModels = db.LawyerModels.Include(l => l.DocumentType);
            //    return View(lawyerModels.ToList());
            //}
            var l = new List<LawyerModel> { new LawyerModel
                                                {
                                                    PersonID = 0,
                                                    FirstName = "Ignacio",
                                                    LastName = "Franco",
                                                    Email = "ign.franco.14@gmail.com",
                                                    CompareEmail = "ign.franco.14@gmail.com",
                                                    CellPhoneNumber = "3492 571726",
                                                    //DateOfBirth = Convert.ToDateTime(25/08/1995),
                                                    DocumentNumber = 39123809,
                                                    ID = 0,
                                                    PersonModelID = 0,
                                                    ProfessionalLicense = 23448,
                                                    //ContractDate = Convert.ToDateTime(20/10/2005)
                                                    },
                                                new LawyerModel
                                                    {
                                                    PersonID = 2,
                                                    FirstName = "Francisco",
                                                    LastName = "Franco",
                                                    Email = "francisco.franco@hotmail.com",
                                                    CompareEmail = "francisco.franco@hotmail.com",
                                                    CellPhoneNumber = "3492-625844",
                                                    //DateOfBirth = Convert.ToDateTime(24/05/2001),
                                                    DocumentNumber = 43225665,
                                                    ID = 2,
                                                    PersonModelID = 2,
                                                    ProfessionalLicense = 23248,
                                                    //ContractDate = Convert.ToDateTime(22/10/2005)
                                                    },
                                                new LawyerModel
                                                {
                                                    PersonID = 1,
                                                    FirstName = "Andrés",
                                                    LastName = "Franco",
                                                    Email = "andres.cai.14@gmail.com",
                                                    CompareEmail = "andres.cai.14@gmail.com",
                                                    CellPhoneNumber = "3492 535726",
                                                    //DateOfBirth = Convert.ToDateTime(21/04/2003),
                                                    DocumentNumber = 44666584,
                                                    ID = 1,
                                                    PersonModelID = 1,
                                                    ProfessionalLicense = 33158,
                                                    //ContractDate = Convert.ToDateTime(20 / 10 / 2005)
                                                }};
            return View(l);
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
