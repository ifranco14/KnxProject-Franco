using KnxProject_Franco.CONTRACTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.CONTRACTS;

namespace KnxProject_Franco.Controllers
{
    public class PersonController : Controller
    {
        private IPerson person;
        private ICourtBranch courtBranch;

        public PersonController(IPerson person, ICourtBranch courtBranch)
        {
            this.person = person;
            this.courtBranch = courtBranch;
        }
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            //TODO: "call a specify server method when a select tag changes"
            //You need 3 different POST methods.And in the initial view just render the < select > Then handle its .change() event 
            //and use ajax to call a server method that returns a partial view of a form for a Lawyer or Client depending on the 
            //selection(which will post back to the corresponding POST method) –

            ViewBag.CourtBranches = new SelectList(courtBranch.GetAllCourtBranches(), "IDCourtBranch", "Name");
            return View();
        }
        
        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel p)
        {
            
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                //crea siempre un cliente porque no recibe el persontype bien
                switch (p.PersonType)
                {
                    case PersonType.Client:
                        ClientModel client = p as ClientModel;
                        return RedirectToAction("Index");
                    case PersonType.Employee:
                        EmployeeModel employee = p as EmployeeModel;
                        return RedirectToAction("Index");
                    case PersonType.Lawyer:
                        LawyerModel lawyer = p as LawyerModel;
                        if (person.CreateLawyer(lawyer))
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.CourtBranches = new SelectList(courtBranch.GetAllCourtBranches(), "IDCourtBranch", "Name");
                            return View(person);
                        }
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CourtBranches = new SelectList(courtBranch.GetAllCourtBranches(), "IDCourtBranch", "Name");
                return View(person);
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
