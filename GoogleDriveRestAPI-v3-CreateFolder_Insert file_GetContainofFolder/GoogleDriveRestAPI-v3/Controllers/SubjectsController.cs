using ElearningSubject.Models;
using ElearningSubject_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Views.Accounts
{
    public class SubjectsController : Controller
    {
        JsTreeModel jsTreeModel = new JsTreeModel();
        Subjects subject = new Subjects();

        // GET: Subjects
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (IsNotLogin())
                return RedirectToAction("Login", "Accounts");
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(string nameSubject, string description)
        {
            string idFolder = GoogleDriveFilesRepository.CreateFolder(nameSubject);
            subject.Add(idFolder,nameSubject, description);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddLesson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLesson(string nameSubject)
        {
            return RedirectToAction("GetSubjectDetailDataList", "Home");
        }

        [HttpGet]
        public ActionResult ModifyItemSubjectDetail(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteItemSubjectDetail(string id)
        {
            return RedirectToAction("GetSubjectDetailDataList","Home");
        }
        public JsonResult GetRoot()
        {
            List<JsTreeModel> items = GetTree();

            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetChildren(string id)
        {
            List<JsTreeModel> items = GetTree(id);
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private List<JsTreeModel> GetTree()
        {
            List<JsTreeModel> items = subject.GetAll();
            return items;
        }

        private List<JsTreeModel> GetTree(string id)
        {
            List<JsTreeModel> items = jsTreeModel.GetDataList().Where(x=>x.parent == id).ToList();
            return items;
        }

        private bool IsNotLogin()
        {
            if (string.IsNullOrEmpty(Session["UserLogin"] + ""))
                return true;
            return false;
        }
    }
}