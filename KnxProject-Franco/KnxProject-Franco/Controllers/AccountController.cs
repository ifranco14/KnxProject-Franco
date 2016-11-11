using KnxProject_Franco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.CONTRACTS;


namespace KnxProject_Franco.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //private IDocumentType documentType;
        private IPerson person;
        public AccountController(IPerson person)
        {
            this.person = person;
        }
        [AllowAnonymous]
        public ActionResult Login(string lastPageURL)
        {
            ViewBag.LastUrl = lastPageURL;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel logger, string lastPageURL)
        {
            if (!WebSecurity.IsAuthenticated)
            {
                try
                {
                    WebSecurity.Login(logger.Email, logger.Password);
                    var x = WebSecurity.IsAuthenticated;
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    return View(logger);
                }
            }
            else
            {
                return View();
            }
                
            
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            //ViewBag.DocumentTypes = documentTypes.GetAll();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ClientModel client)
        {
            if (ModelState.IsValid && !WebSecurity.UserExists(client.Email))
            {
                client.PersonType2 = "Client";
                person.CreateClient(client);
                string ImageName = System.IO.Path.GetFileName(client.Image.FileName);
                string physicalPath = Server.MapPath("~/Content/img/Clients/" + ImageName);
                // Guardo en la carpeta de imagenes
                client.Image.SaveAs(physicalPath);
                WebSecurity.Login(client.Email, client.Password);
                return View(); //TODO: return to a "profile" view
            }
            else
            {
                return View(client);
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}