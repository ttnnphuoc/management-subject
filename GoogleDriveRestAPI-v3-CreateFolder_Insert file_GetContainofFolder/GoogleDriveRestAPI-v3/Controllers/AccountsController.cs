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
        Roles roles = new Roles();
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
            if (username.Trim() != "" && password.Trim() != "")
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
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            user.SendMail(email);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (IsNotLogin())
                return RedirectToAction("Login");
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string password0, string password1)
        {
            if (IsNotLogin())
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
        public ActionResult ChangeInfoAccount(int? id)
        {
            if (IsNotLogin())
                return RedirectToAction("Login");
            int idx = int.Parse(Session["IDLogin"] + "");
            ViewBag.ListDepartment = department.GetAll(0, "1");
            return View(user.GetAll(idx).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult ChangeInfoAccount(Users user)
        {
            user.Update(user);
            return RedirectToAction("ChangeInfoAccount", "Accounts", new { id = user.ID });
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

        public ActionResult LogOut()
        {
            Session["UserLogin"] = null;
            Session["IDLogin"] = null;
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult EditPermistion(int id)
        {
            if (IsNotLogin())
                return RedirectToAction("Login");
            ViewBag.ListRoles = roles.GetAll();
            ViewBag.ListDepartment = department.GetAll();
            return View(user.GetAll(id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditPermistion(int ID,string Roles, string IDDepartment, bool Status = false)
        {
            Users u = new Users();
            u.ID = ID+"";
            u.Roles = Roles;
            u.IDDepartment = IDDepartment;
            u.Status = Status;
            u.UpdatePermission(u);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
             if (IsNotLogin())
                return RedirectToAction("Login");
            user.Delete(id);
            return RedirectToAction("Index");
        }

        private bool IsNotLogin()
        {
            if (string.IsNullOrEmpty(Session["UserLogin"] + ""))
                return true;
            return false;
        }
    }
}