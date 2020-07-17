﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Views.Accounts
{
    public class SubjectsController : Controller
    {
        ContentSubject content = new ContentSubject();

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
            ContentSubject item = content.PrepareData().Find(x => x.Index + "" == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteItemSubjectDetail(string id)
        {
            return RedirectToAction("GetSubjectDetailDataList","Home");
        }

    }
}