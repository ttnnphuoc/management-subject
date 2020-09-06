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
        UserSubject subjecUser = new UserSubject();
        Lessons lesson = new Lessons();
        // GET: Subjects
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return View(subject.GetListSubjectByUser(Session["IDLogin"] + ""));
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(string nameSubject, string description)
        {
            string idFolder = GoogleDriveFilesRepository.CreateFolder(nameSubject);
            subject.Add(idFolder,nameSubject, description);
            subjecUser.Add(idFolder, Session["IDLogin"] + "");
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult DeleteItemSubjectDetail(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return RedirectToAction("GetSubjectDetailDataList","Home");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            Subjects sub = subject.GetSubjectById(id);
            return View(sub);
        }

        [HttpPost]
        public ActionResult Edit(Subjects sub)
        {
            return View();
        }

        #region Get Folder Subject
        public JsonResult GetRoot()
        {
            List<JsTreeModel> items = subject.GetAllTreeFolder();
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetChildren(string id)
        {
            List<JsTreeModel> items = lesson.GetLessonBySubject(id);
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion
    }
}