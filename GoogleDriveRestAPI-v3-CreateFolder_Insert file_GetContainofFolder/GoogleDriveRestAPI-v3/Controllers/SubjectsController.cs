using Core;
using ElearningSubject.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Add(Subjects sub)
        {
            Subjects subExists = GetSubjectByName(sub);
            if (subExists != null && subExists.ID != "")
            {
                return Json(new { rs = false, msg = "Môn học đã tồn tại" });
            }
            string newId = this.GetNextIDSubject();
            sub.Description = string.IsNullOrEmpty(sub.Description)? sub.Name : sub.Description;

            subject.Add(newId, sub.Name.Trim(), sub.Description.Trim());
            subjecUser.Add(newId, Session["IDLogin"] + "");
            return Json(new { rs = true, msg = "Thêm thông tin thành công" });
        }
        
        [HttpPost]
        public ActionResult DeleteItemSubjectDetail(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return RedirectToAction("GetSubjectDetailDataList","Home");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            subject.Delete(id);
            return RedirectToAction("Index", "Subjects");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            Subjects sub = subject.GetSubjectById(id);
            ViewBag.Name = sub.Name;
            return View(sub);
        }

        [HttpPost]
        public ActionResult Edit(Subjects sub)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            sub.Description = sub.Description.Trim();
            sub.Status = 1;
            subject.Update(sub);
            return RedirectToAction("Index","Subjects");
        }

        private Subjects GetSubjectByName(Subjects sub)
        {
            try
            {
                Subjects subj = subject.GetSubjectByName(sub);
                return subj;
            }
            catch(Exception ex)
            {
                return new Subjects();
            }
        }
        #region Get Folder Subject
        public JsonResult GetRoot()
        {
            List<JsTreeModel> items = subject.GetAllTreeFolder("","", Session["IDLogin"] + "");
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetChildren(string id)
        {
            List<JsTreeModel> items = lesson.GetLessonBySubject(id);
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        #endregion
        private string GetNextIDSubject()
        {
            Subjects sub = CBO.FillObject<Subjects>(DataProvider.Instance.ExecuteReader("GetNextID", "Subjects"));
            if (sub == null || Null.IsNull(sub.ID))
            {
                return "MH01";
            }

            string currentID = sub.ID.Replace("MH", "");
            long currentNumber = long.Parse(currentID);
            return string.Format("MH{0:00}", currentNumber + 1);
        }
    }
}