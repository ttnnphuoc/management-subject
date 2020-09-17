using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return View();
        }
    }
}