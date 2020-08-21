using ElearningSubject.Models;
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
        // GET: Subjects
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string nameSubject)
        {
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
            var items = new List<JsTreeModel>();
            items.Add(new JsTreeModel("1", "#", "Lập trình ngôn ngữ C#", true));
            items.Add(new JsTreeModel("2", "#", "Học lập trình C/C++", true));
            // set items in here

            return items;
        }

        private List<JsTreeModel> GetTree(string id)
        {
            List<JsTreeModel> items = jsTreeModel.GetDataList().Where(x=>x.parent == id).ToList();
            return items;
        }
    }
}