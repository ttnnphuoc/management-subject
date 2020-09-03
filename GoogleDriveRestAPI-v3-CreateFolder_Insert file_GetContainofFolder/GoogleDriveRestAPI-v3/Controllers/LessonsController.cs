using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class LessonsController : Controller
    {
        Subjects subject = new Subjects();
        Lessons lessons = new Lessons();
        // GET: Lessons
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddLesson(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            Subjects sub = subject.GetSubjectById(id);
            ViewBag.Title = "Thêm Bài Học Mới " + sub.Name;
            return View(sub);
        }

        [HttpPost]
        public ActionResult AddLesson(string nameLesson, HttpPostedFileBase fileDocumentPDF, HttpPostedFileBase videoFile,HttpPostedFileBase fileDocumentWord,HttpPostedFileBase fileDocumentPPT, string idSubject)
        {
            //lessons.Add(new Lessons());
            return RedirectToAction("Index", "Subjects");
        }
        public ActionResult GetSubjectDetailDataList(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            Subjects sub = subject.GetSubjectById(id);
            ViewBag.Subject = sub;
            List<Lessons> data = lessons.GetAll("", "", id);
            return View(data);
        }
        
    }
}