using ElearningSubject.Models;
using ElearningSubject_v3.Models;
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
        public ActionResult AddLesson(string nameLesson,HttpPostedFileBase fileDocumentWord, HttpPostedFileBase fileDocumentPPT, HttpPostedFileBase fileDocumentPDF, HttpPostedFileBase videoFile, string idSubject, string description)
        {
            List<string> parentId = new List<string>();
            parentId.Add(idSubject);
            string idFolder = GoogleDriveFilesRepository.CreateFolder(nameLesson,parentId);
            string word =  GoogleDriveFilesRepository.FileUploadInFolder(idFolder, fileDocumentWord);
            string ppt = GoogleDriveFilesRepository.FileUploadInFolder(idFolder, fileDocumentPPT);
            string pdf = GoogleDriveFilesRepository.FileUploadInFolder(idFolder, fileDocumentPDF);
            string video = GoogleDriveFilesRepository.FileUploadInFolder(idFolder, videoFile);

            #region Add Lesson
            Lessons item = new Lessons();
            item.ID = idFolder;
            item.Name = nameLesson;
            item.PPTFile = ppt;
            item.WordFile = word;
            item.PdfFile = pdf;
            item.Video = video;
            item.DateCreated = DateTime.Now;
            item.IDSubject = idSubject;
            item.Description = description;
            lessons.Add(item);
            #endregion

            #region Update Subject
            subject.UpdateChildren(idSubject);
            #endregion
            return RedirectToAction("Index", "Subjects");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Lessons less)
        {
            lessons.Update(less);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            lessons.Delete(id);
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
        public ActionResult GetFileByFolderID(string id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            List<GoogleDriveFiles> data = GoogleDriveFilesRepository.GetContainsInFolder(id);
            ViewBag.Lesson = lessons.GetAll(id).AsEnumerable().FirstOrDefault();
            return View(data);
        }
    }
}