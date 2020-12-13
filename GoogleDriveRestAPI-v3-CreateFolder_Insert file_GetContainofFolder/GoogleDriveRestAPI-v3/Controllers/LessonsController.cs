using Core;
using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AddLesson(string nameLesson,HttpPostedFileBase fileDocumentWord, HttpPostedFileBase fileDocumentPPT, HttpPostedFileBase fileDocumentPDF, string urlVideo, string idSubject, string description)
        {
            if (nameLesson.Equals("") || urlVideo.Length == 0)
            {
                TempData["Error"] = "Dữ liệu (*) không được để trống";
                return RedirectToAction("AddLesson", "Lessons", new { id = idSubject });
            }
            #region Add Lesson
            Lessons item = new Lessons();
            item.ID = this.GetNextIDSubject();

            item.Name = nameLesson;
            item.PPTFile = UploadsFile(fileDocumentPPT);
            item.WordFile = UploadsFile(fileDocumentWord);
            item.PdfFile = UploadsFile(fileDocumentPDF);
            item.Video = urlVideo;
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
            Lessons lessonData = lessons.GetAll(id).AsEnumerable().FirstOrDefault();
            Subjects subjectCurrent = subject.GetSubjectById(lessonData.IDSubject);
            ViewBag.SubjectTitle = subjectCurrent.Name;
            ViewBag.BaseUrl = GetBaseUrl();
            return View(lessonData);
        }

        [HttpGet]
        public ActionResult EditPPT(string id,string file)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            ViewBag.BaseUrl = this.GetBaseUrl();
            GetInfoFile(id, file);
            return View();
        }

        [HttpPost]
        public ActionResult EditPPT(string id, string fileOld, HttpPostedFileBase file)
        {
            bool isOk = false;
            if (file != null)
            {
                DeleteFileOld(fileOld);
                isOk = lessons.UpdateFileID("PPTFile", UploadsFile(file), id);
            }
            if (isOk)
            {
                TempData["Error"] = "Cập Nhật Thành Công-OK";
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditWord(string id, string file)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            GetInfoFile(id, file);
            ViewBag.BaseUrl = this.GetBaseUrl();
            return View();
        }
        private void DeleteFileOld(string fileName)
        {
            string path = GetPathFile(fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        [HttpPost]
        public ActionResult EditWord(string id, string fileOld, HttpPostedFileBase file)
        {
            bool isOk = false;
            if (file != null)
            {
                DeleteFileOld(fileOld);
                isOk = lessons.UpdateFileID("PPTFile", UploadsFile(file), id);
            }
            if (isOk)
            {
                TempData["Error"] = "Cập Nhật Thành Công-OK";
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditPDF(string id, string file)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            GetInfoFile(id, file);
            ViewBag.BaseUrl = this.GetBaseUrl();
            return View();
        }
        private string GetPathFile(string fileName)
        {
            return Path.Combine(Server.MapPath("~/Uploads/TaiLieu"),
                                             Path.GetFileName(fileName));
        }
        [HttpPost]
        public ActionResult EditPDF(string id, string fileOld, HttpPostedFileBase file)
        {
            bool isOk = false;
            if (file != null)
            {
                DeleteFileOld(fileOld);
                isOk = lessons.UpdateFileID("PPTFile", UploadsFile(file), id);
            }
            if (isOk)
            {
                TempData["Error"] = "Cập Nhật Thành Công-OK";
            }
            return RedirectToAction("Index", "Home");
        }

        private void GetInfoFile(string id, string file)
        {
            ViewBag.FileOld = file;
            ViewBag.ParentId = id;
            ViewBag.Lesson = lessons.GetAll(id).FirstOrDefault();
            Subjects sub = subject.GetSubjectById(ViewBag.Lesson.IDSubject);
            ViewBag.Title = string.Format("{0} - {1}", ViewBag.Lesson.Name, sub.Name);
        }

        private string GetNextIDSubject()
        {
            Lessons less = CBO.FillObject<Lessons>(DataProvider.Instance.ExecuteReader("GetNextID", "Lessons"));
            if (less == null || Null.IsNull(less.ID))
            {
                return "BH001";
            }

            string currentID = less.ID.Replace("BH", "");
            long currentNumber = long.Parse(currentID);
            return string.Format("BH{0:000}", currentNumber + 1);
        }
        private string UploadsFile(HttpPostedFileBase file)
        {
            string path = "";
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    path = Path.Combine(Server.MapPath("~/Uploads/TaiLieu"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return file.FileName;
        }
        private string GetBaseUrl()
        {
            var request = System.Web.HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl.Remove(baseUrl.Length -1);
        }
    }
}