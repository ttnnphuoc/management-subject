using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class AccountsController : Controller
    {
        Users user = new Users();
        Departments department = new Departments();
        // GET: Accounts
        public ActionResult Index()
        {
            if (IsNotLogin())
                return RedirectToAction("Login");
            return View(user.GetAll());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if(username.Trim() != "" && password.Trim() != "")
            {
                Users u = user.Login(username, password);
                if (u != null && u.Email != "")
                {
                    Session["UserLogin"] = u.Email;
                    Session["IDLogin"] = u.ID;
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (IsNotLogin())
                return RedirectToAction("Login");
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string password0,string password1)
        {
            if(IsNotLogin())
                return RedirectToAction("Login");
            if ((password0 == "" && password1 == "") || password0 != password1)
            {
                ViewBag.Error = "Mật khẩu không khớp";
                return View();
            }
            user.ChangePassword(Session["UserLogin"] + "", password1);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ChangeInfoAccount()
        {
            if (IsNotLogin())
                return RedirectToAction("Login");
            int id = int.Parse(Session["IDLogin"]+"");
            return View(user.GetAll(id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult ChangeInfoAccount(Users user)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.ListDepartment = department.GetAll(0, "1");
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            user.DateCreated = DateTime.Now;
            user.Add(user);
            return RedirectToAction("Login");
        }
        private bool IsNotLogin()
        {
            if (string.IsNullOrEmpty(Session["UserLogin"] + ""))
                return true;
            return false;
        }
    }
}