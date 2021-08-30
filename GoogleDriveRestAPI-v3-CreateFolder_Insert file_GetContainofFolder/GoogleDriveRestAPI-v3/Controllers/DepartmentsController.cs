using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class DepartmentsController : Controller
    {
        private Departments department = new Departments();
        // GET: Departments
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return View(department.GetAll());
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        public ActionResult Create(Departments dep)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            try
            {
                department.Add(dep);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            ViewBag.Dept = department.GetAll(id).FirstOrDefault();
            return View();
        }

        // POST: Departments/Edit/5
        [HttpPost]
        public ActionResult Edit(Departments dep)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            try
            {
                department.Update(dep);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            department.Delete(id);
            return RedirectToAction("Index");
        }
      
    }
}
