using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static KnxProject_Franco.MvcApplication;

namespace KnxProject_Franco.Controllers
{
    public class HomeController : Controller
    {
        private IAbout about;

        public HomeController(IAbout about)
        {
            this.about = about;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View(about.Get(10));
        }

        // GET: Home/Edit/
        [Authorize(Roles = "admin,secretary")]
        [HandleError(View ="~/Home/Error")]
        public ActionResult Edit()
        {
            return View(about.Get(10));
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,secretary")]
        [HandleError(View ="~/Shared/LoginError")]
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

        [AllowAnonymous]
        public ActionResult LoginError()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Unauthorized()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult BadRequest()
        {
            return View();
        }


        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (filterContext.HttpContext.Response.StatusCode == 401)
        //        filterContext.Result = RedirectToAction("LoginError", "Home");
        //    else
        //        base.OnActionExecuting(filterContext);
        //}
    }
}