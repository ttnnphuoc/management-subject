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
        Users user = new Users();
        Departments dep = new Departments();
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            ViewBag.ListDepartment = dep.GetAll();
            ViewBag.ListUser = user.GetAll();
            return View();
        }
        //public JsonResult GetAllUser()
        //{
        //    return new JsonResult { Data = user.GetAll(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
    }
}