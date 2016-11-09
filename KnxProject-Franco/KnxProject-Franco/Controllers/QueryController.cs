using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using WebMatrix.WebData;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace KnxProject_Franco.Controllers
{
    public class QueryController : Controller
    {
        private IPerson person;
        private IQA query;
        private ICourtCase courtCase;
        private ICourtCaseDetails courtCaseDetails;
        private ICourtBranch courtBranch;
        private IStates state;

        public QueryController(IPerson person, IQA query, ICourtCase courtCase, ICourtCaseDetails courtCaseDetails, ICourtBranch courtBranch, IStates state)
        {
            this.query = query;
            this.person = person;
            this.courtCase = courtCase;
            this.courtCaseDetails = courtCaseDetails;
            this.courtBranch = courtBranch;
            this.state = state;
        }
        // GET: Query
        [Authorize(Roles ="lawyer,client")]
        public ActionResult Index()
        {
            ViewBag.CourtCases = courtCase.GetAll();
            ViewBag.CourtCaseDetails = courtCaseDetails.GetAll();
            ViewBag.States = state.GetAll();
            if (Roles.IsUserInRole("lawyer"))
            {
                ViewBag.QueryCounter = query.UnansweredQuerysLawyer(person.GetID(person.GetIDPerson(WebSecurity.CurrentUserId)));
                ViewBag.Clients = person.GetAllClients();
                return View(query.GetAllOfALawyer(person.GetID(person.GetIDPerson(WebSecurity.CurrentUserId))));
            }
            else
            {
                ViewBag.QueryCounter = query.UnansweredQuerysClient(person.GetID(person.GetIDPerson(WebSecurity.CurrentUserId)));
                ViewBag.Lawyers = person.GetAllLawyers();
                return View(query.GetAllOfAClient(person.GetID(person.GetIDPerson(WebSecurity.CurrentUserId))));
            }
        }

        
        [Authorize(Roles = "lawyer,client")]
        // GET: Query/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Query/Create
        [Authorize(Roles = "client")]
        ///ESPERA UN ID DE COURTCASEDETAIL
        public ActionResult Create(int id)
        {            
            var ccd = courtCaseDetails.GetCourtCaseDetail(id);
            ViewBag.CourtCaseDetail = ccd;
            var cc = courtCase.GetCourtCase(ccd.IDCourtCase);
            ViewBag.CourtCase = cc;
            ViewBag.Client = person.GetClient(cc.IDClient);
            ViewBag.Lawyer = person.GetLawyer(cc.IDLawyer);
            return View();
        }

        // POST: Query/Create
        [Authorize(Roles="client")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Include = "IDCourtCase,IDQA,IDCourtCaseDetail,IDLawyer,IDClient,Query")]QAModel q)
        {
            if (ModelState.IsValid)
            {
                q.SendDate = DateTime.Today;
                query.Create(q);
                return RedirectToAction("Index");
            }
            else
            {
                return View(q);
            }
        }

        // GET: Query/CreateAnonymous
        [AllowAnonymous]
        public ActionResult CreateAnonymous()
        {
            ViewBag.Lawyers = person.GetAllLawyers();
            ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
            return View();
        }

        // POST: Query/CreateAnonymous
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateAnonymous([Bind(Include = "IDQA,IDLawyer,Query,SendDate,Name,Mail")]QAModel q)
        {
            if (ModelState.IsValid)
            {
                query.Create(q);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(q);
            }
        }

        [Authorize(Roles = "lawyer")]
        public ActionResult Answer(int id)
        {
            return View(query.GetQuery(id));
        }

        [Authorize(Roles = "lawyer")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Answer([Bind(Include = "IDQA,Answer")]QAModel q)
        {
            //TODO: responder a una consulta de un cliente
            if (ModelState.IsValid)
            {
                query.AnswerQuestion(q.IDQA, q);
                return RedirectToAction("Index");
            }
            else
            {
                return View(q);
            }

            
        }
        [Authorize(Roles="lawyer")]
        public ActionResult AnswerAnonymous(int id)
        {
            return View(query.GetQuery(id));
        }
        //Probar si anda
        [Authorize(Roles = "lawyer")]
        [ValidateAntiForgeryToken]
        public ActionResult AnswerAnonymous([Bind(Include = "Answer,Name,Mail")]QAModel q)
        {
            var lawyer = person.GetPerson(person.GetIDPerson(WebSecurity.CurrentUserId));
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(q.Mail));
            mail.From = new MailAddress(lawyer.Email);
            mail.Subject = "Asunto: Consulta a K.U. & Asociados - "+ lawyer.FirstName +" "+lawyer.LastName;
            mail.Body = q.Answer;
            mail.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("kuasociados@gmail.com", "kuasociados123");

            var output = "";
            try
            {
                smtp.Send(mail);
                mail.Dispose();
                output = "Correo electrónico fue enviado satisfactoriamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
                return View(q);
            }
        }
    }
}
