using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangeInfoAccount()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
    }
}