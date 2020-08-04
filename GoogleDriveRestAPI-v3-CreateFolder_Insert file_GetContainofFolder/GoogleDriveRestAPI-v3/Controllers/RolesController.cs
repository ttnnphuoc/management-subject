using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class RolesController : Controller
    {
        private Roles roles = new Roles();
        // GET: Roles
        public ActionResult Index()
        {
            return View(roles.GetAll());
        }
        public ActionResult AddRoles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRoles(string nameRole, string description)
        {
            roles.Add(nameRole, description);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Roles role = roles.GetAll(id).FirstOrDefault();
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(Roles roles)
        {
            roles.Update(roles);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            roles.Delete(id);
            return RedirectToAction("Index");
        }
    }
}