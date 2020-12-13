using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class ManagerStudentsController : Controller
    {
        Subjects subject = new Subjects();
        Users user = new Users();
        // GET: ManagerStudents
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            ViewBag.Subject = subject.GetListSubjectByUser(Session["IDLogin"] + "");
            return View();
        }

        public JsonResult GetUserByRole()
        {
            Users usLogin = user.GetAll(Session["IDLogin"] + "").FirstOrDefault();
            List<Users> items = user.GetAllByRole("0", "", usLogin.IDDepartment, "4");
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}