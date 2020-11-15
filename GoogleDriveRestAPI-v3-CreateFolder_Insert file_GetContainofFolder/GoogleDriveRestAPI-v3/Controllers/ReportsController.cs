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
        ReportModel rp = new ReportModel();
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            ViewBag.ListDepartment = dep.GetAll();
            ViewBag.ListUser = user.GetAll();
            return View(rp.GetAll());
        }
        #region Get Folder Subject
        public JsonResult GetRoot()
        {
            List<JsTreeModel> items = rp.GetAllTreeDeparment();
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetChildren(string id)
        {
            List<JsTreeModel> items = rp.GetAllTreeUser(id);
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetChildrenSubject(string id)
        {
            List<JsTreeModel> items = rp.GetAllTreeSubject(id);
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetChildrenLesson(string id)
        {
            List<JsTreeModel> items = rp.GetChildrenLesson(id);
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion
    }
}