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
        UserSubject subjecUser = new UserSubject();
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
        public JsonResult AddStudentToSubject(string[] data)
        {
            foreach (string item in data)
            {
                string[] arrParam = item.Split('_');
                string action = arrParam[0] + "";
                string usId = arrParam[1] + "";
                string subId = arrParam[2] + "";
                UserSubject usrSub = subjecUser.GetSubjectUserData(subId, usId);
                switch (action)
                {
                    case "D":
                        if (usrSub != null)
                        {
                            subjecUser.Delete(subId, usId);
                        }
                        break;
                    case "C":
                        if (usrSub == null)
                        {
                            subjecUser.Add(subId, usId);
                        }
                        break;
                }
            }
            return new JsonResult { Data = "Cập nhật thông tin môn học cho sinh viên thành công", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}