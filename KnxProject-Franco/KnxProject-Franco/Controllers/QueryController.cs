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
            if(WebSecurity.IsAuthenticated && Roles.IsUserInRole("client"))
            {
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.Lawyers = person.GetAllLawyers();
                ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
                return View();
            }            
        }

        // POST: Query/CreateAnonymous
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateAnonymous([Bind(Include = "IDQA,IDLawyer,Query,SendDate,Name,Mail,Topic")]QAModel q)
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


        [Authorize(Roles="lawyer")]
        public ActionResult AnswerClient(int id)
        {
            var q = query.GetQuery(id);
            ViewBag.CourtCase = courtCase.GetCourtCase(q.IDCourtCase);
            ViewBag.Lawyer = person.GetLawyer(q.IDLawyer);
            ViewBag.Client = person.GetClient(q.IDClient);
            ViewBag.CourtCaseDetail = courtCaseDetails.GetCourtCaseDetail(q.IDCourtCaseDetail);
            return View(q);
        }

        [Authorize(Roles="lawyer")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AnswerClient([Bind(Include = "IDCourtCase,IDQA,IDCourtCaseDetail,IDLawyer,IDClient,Query,Answer")]QAModel myQ)
        {
            if (ModelState.IsValid)
            {
                query.AnswerQuestion(myQ.IDQA, myQ);

                var lawyer = person.GetPerson(person.GetIDPerson(WebSecurity.CurrentUserId));
                var client = person.GetClient(myQ.IDClient);
                myQ.AnswerDate = DateTime.Today;
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(client.Email));
                mail.From = new MailAddress(lawyer.Email);
                mail.Subject = "Asunto: Consulta a K.U. & Asociados - " + lawyer.FirstName + " " + lawyer.LastName;
                mail.Body = "Sobre tu consulta: \r\n";
                mail.Body += myQ.Query + " \r\n ";
                mail.Body += "El abogado te contestó: \r\n ";
                mail.Body += myQ.Answer + "";
                mail.Priority = MailPriority.Normal;

                var fromAddress = new MailAddress("kuasociados@gmail.com");
                var fromPassword = "kuasociados123";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

                var output = "";
                try
                {
                    smtp.Send(mail);
                    mail.Dispose();
                    output = "Correo electrónico fue enviado satisfactoriamente.";
                    query.Delete(myQ.IDQA);
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(myQ);
            }
            
        }
        
        [Authorize(Roles="lawyer")]
        public ActionResult AnswerAnonymous(int id)
        {
            var myQ = query.GetQuery(id);
            return View(myQ);
        }
        //Probar si anda
        [Authorize(Roles = "lawyer")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AnswerAnonymous([Bind(Include = "Answer,Name,Mail,IDQA")]QAModel q)
        {
            var lawyer = person.GetPerson(person.GetIDPerson(WebSecurity.CurrentUserId));
            q.AnswerDate = DateTime.Today;
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(q.Mail));
            mail.From = new MailAddress(lawyer.Email);
            mail.Subject = "Asunto: Consulta a K.U. & Asociados - " + lawyer.FirstName + " " + lawyer.LastName+" "+q.Topic;
            mail.Body = "Sobre tu consulta: \r\n";
            mail.Body += q.Query + " \r\n ";
            mail.Body += "El abogado te contestó: \r\n ";
            mail.Body += q.Answer + "";
            mail.Priority = MailPriority.Normal;

            var fromAddress = new MailAddress("kuasociados@gmail.com");
            var fromPassword = "kuasociados123";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

            var output = "";
            try
            {
                smtp.Send(mail);
                mail.Dispose();
                output = "Correo electrónico fue enviado satisfactoriamente.";
                query.Delete(q.IDQA);
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
