using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class EmailsController : Controller
    {
        Emails email = new Emails();
        // GET: Emails

        [HttpGet]
        public ActionResult Index()
        {
            if(CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login","Accounts");

            List<Emails> em = email.GetListEmail();
            if (em == null || em.Count == 0)
                return View();

            return View(em);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Emails email)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Emails em = email.GetEmailByStatus(id);
            return View(em);
        }

        [HttpPost]
        public ActionResult Edit(string id, string status)
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            return View("Index");
        }
    }
}