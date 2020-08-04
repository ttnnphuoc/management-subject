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
            return View(department.GetAll());
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        public ActionResult Create(Departments dep)
        {
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
            return View(department.GetAll(id).FirstOrDefault());
        }

        // POST: Departments/Edit/5
        [HttpPost]
        public ActionResult Edit(Departments dep)
        {
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
            department.Delete(id);
            return RedirectToAction("Index");
        }
      
    }
}
