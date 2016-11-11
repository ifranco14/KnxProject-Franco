using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnxProject_Franco.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IAbout about;

        public HomeController(IAbout about)
        {
            this.about = about;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View(about.Get(10));
        }

        // GET: Home/Edit/
        [Authorize(Roles = "admin,secretary")]
        public ActionResult Edit()
        {
            return View(about.Get(10));
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,secretary")]
        public ActionResult Edit([Bind(Include = "ID,Description,Mission,Vision,Address,City,Phone,Functions,History")] AboutModel a)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                if (about.Edit(10, a))
                {
                    return RedirectToAction("About");
                }
                else
                {
                    return View(a);
                }

            }
            else
            {
                return View(a);
            }
        }

    }
}