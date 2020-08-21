using ElearningSubject_v3.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject_v3.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult GetGoogleDriveFiles()
        {
            return View(GoogleDriveFilesRepository.GetDriveFiles());
        }

        [HttpGet]
        public ActionResult GetContainsInFolder(string folderId)
        {
            return View(GoogleDriveFilesRepository.GetContainsInFolder(folderId));
        }

        [HttpPost]
        public ActionResult CreateFolder(String FolderName)
        {
            GoogleDriveFilesRepository.CreateFolder(FolderName);
            return RedirectToAction("GetGoogleDriveFiles");
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            GoogleDriveFilesRepository.FileUpload(file);
            return RedirectToAction("GetGoogleDriveFiles");
        }

        [HttpPost]
        public ActionResult FileUploadInFolder(GoogleDriveFiles FolderId, HttpPostedFileBase file)
        {
            GoogleDriveFilesRepository.FileUploadInFolder(FolderId.Id, file);
            return RedirectToAction("GetGoogleDriveFiles");
        }
        [HttpGet]
        public ActionResult Index()
        {
            //if (IsNotLogin())
            //    return RedirectToAction("Login","Accounts");
            return View();
        }

        [HttpGet]
        public ActionResult GetSubjectDetailDataList(string id)
        {
            return View();
        }
        public ActionResult ShowDetailSubject(string id)
        {
            return View();
        }
        private bool IsNotLogin()
        {
            if (string.IsNullOrEmpty(Session["UserLogin"] + ""))
                return true;
            return false;
        }
    }
}