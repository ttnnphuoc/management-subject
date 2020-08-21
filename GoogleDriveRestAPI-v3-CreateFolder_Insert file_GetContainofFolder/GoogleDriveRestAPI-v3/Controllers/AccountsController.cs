using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            List<Users> data = new List<Users>();
            Users u = user.GetAll(Session["IDLogin"] + "").FirstOrDefault();
            switch (u.Roles)
            {
                case "2":
                    data = user.GetAll("0","",u.IDDepartment).Where(x=>x.Roles != "3" && x.ID != u.ID).ToList();
                    break;
                case "3":
                    data = user.GetAll().Where(x => x.Roles != "3" && x.ID != u.ID).ToList();
                    break;
            }
            return View(data);
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (!IsNotLogin())
                return RedirectToAction("Index", new { controller = "Home", area = string.Empty });
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
                    return RedirectToAction("Index", new { controller = "Home", area = string.Empty });
                }
            }

            ViewBag.Error = "Tải khoản hoặc mật khẩu không đúng. Hoặc tài khoản đã bị khóa";
            return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            if(email == "" || !(new EmailAddressAttribute().IsValid(email)))
            {
                ViewBag.Error = "Email không đúng định dạng.";
                return View();
            }
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
                ViewBag.Error = "Mật khẩu không khớp hoặc đang để trống";
                return View();
            }
            user.ChangePassword(Session["UserLogin"] + "", password1);
            return RedirectToAction("Index", new { controller = "Home", area = string.Empty });
        }

        [HttpGet]
        public ActionResult ChangeInfoAccount(int? id)
        {
            TempData["Error"] = "";
            if (IsNotLogin())
                return RedirectToAction("Login");
            ViewBag.ListDepartment = department.GetAll(0, "1");
            return View(user.GetAll(Session["IDLogin"] + "").FirstOrDefault());
        }

        [HttpPost]
        public ActionResult ChangeInfoAccount(Users user)
        {
            if (user.Fullname +""== "")
            {
                TempData["Error"] = "Tên không được bỏ trống";
            } else
            {
                user.Update(user);
            }
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
            if (user.Fullname+"" == "" || user.Email+"" == "" || user.Password+"" == "")
            {
                ViewBag.Error = "Tên, Email, Password không được để trống";
                ViewBag.ListDepartment = department.GetAll(0, "1");
                return View();
            }

            Users u = user.GetAll().Where(x => x.Email.Equals(user.Email.Trim())).FirstOrDefault();
            if (u != null)
            {
                ViewBag.Error = "Email đã đươc đăng ký. Vui lòng kiểm tra lại";
                ViewBag.ListDepartment = department.GetAll(0, "1");
                return View();
            }

            user.DateCreated = DateTime.Now;
            user.Add(user);
            return RedirectToAction("Login", new { controller = "Accounts", area = string.Empty });

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
            return View(user.GetAll(id+"").FirstOrDefault());
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