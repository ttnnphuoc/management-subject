using ElearningSubject.Models;
using ElearningSubject_v3.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject_v3.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return View();
        }
        
    }
}