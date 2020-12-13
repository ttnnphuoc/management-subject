using Core;
using ElearningSubject.Models;
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
        public ActionResult Add(string nameSubject, string description)
        {
            if (string.IsNullOrEmpty(nameSubject))
            {
                ViewBag.Error = "Vui lòng nhập tên môn học.";
                return RedirectToAction("Index");
            }

            string newId = this.GetNextIDSubject();
            description = description.Length == 0 ? nameSubject : description;

            subject.Add(newId, nameSubject.Trim(), description.Trim());
            subjecUser.Add(newId, Session["IDLogin"] + "");
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
        public ActionResult Delete(string id)
        {
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
            sub.Description = sub.Description.Trim();
            sub.Status = 1;
            subject.Update(sub);
            return RedirectToAction("Index","Subjects");
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