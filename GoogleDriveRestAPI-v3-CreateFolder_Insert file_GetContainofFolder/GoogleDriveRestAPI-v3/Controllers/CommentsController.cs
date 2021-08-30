using ElearningSubject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        private Comments cmtModel = new Comments();
        public ActionResult GetCommentList(Comments data)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            try
            {
                List<Comments> dataa = cmtModel.GetListComment(data);
                return Json(new { rs = true, commentList = dataa }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rs = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add(Comments data)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            try
            {
                data.USERID = Session["IDLogin"] + "";
                cmtModel.Add(data);
                return Json(new { rs = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { rs = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}