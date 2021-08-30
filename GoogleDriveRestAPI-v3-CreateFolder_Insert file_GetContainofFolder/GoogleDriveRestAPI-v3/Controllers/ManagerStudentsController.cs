using ElearningSubject.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningSubject.Controllers
{
    public class ManagerStudentsController : Controller
    {
        Subjects subject = new Subjects();
        Users user = new Users();
        UserSubject subjecUser = new UserSubject();
        // GET: ManagerStudents
        public ActionResult Index()
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            ViewBag.Subject = subject.GetListSubjectByUser(Session["IDLogin"] + "");
            return View();
        }

        public JsonResult GetUserByRole()
        {
            Users usLogin = user.GetAll(Session["IDLogin"] + "").FirstOrDefault();
            List<Users> items = user.GetAllByRole("0", "", usLogin.IDDepartment, "4");
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult AddStudentToSubject(string[] data)
        {
            foreach (string item in data)
            {
                string[] arrParam = item.Split('_');
                string action = arrParam[0] + "";
                string usId = arrParam[1] + "";
                string subId = arrParam[2] + "";
                UserSubject usrSub = subjecUser.GetSubjectUserData(subId, usId);
                switch (action)
                {
                    case "D":
                        if (usrSub != null)
                        {
                            subjecUser.Delete(subId, usId);
                        }
                        break;
                    case "C":
                        if (usrSub == null)
                        {
                            subjecUser.Add(subId, usId);
                        }
                        break;
                }
            }
            return new JsonResult { Data = "Cập nhật thông tin môn học cho sinh viên thành công", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult AddStudentToSubjectFile(HttpPostedFileBase file)
        {
            if (CommonFunc.IsNotLogin(Session["UserLogin"] + ""))
                return RedirectToAction("Login", "Accounts");
            if ((file != null) && !string.IsNullOrEmpty(file.FileName))
            {
                string fileName = file.FileName;
                string fileContentType = file.ContentType;
                byte[] fileBytes = new byte[file.ContentLength];
                var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        string email = workSheet.Cells[rowIterator, 1].Value + "";
                        string subjectID = workSheet.Cells[rowIterator, 2].Value + "";
                        string acction = workSheet.Cells[rowIterator, 3].Value + "";
                        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(subjectID))
                        {
                            UserSubject usrSub = subjecUser.GetSubjectUserDataEmail(subjectID, email);
                            Users usr = user.GetUserByEmail(email);

                            if (usrSub == null)
                            {
                                if(usr!=null && user.ID != "")
                                {
                                    subjecUser.Add(subjectID, usr.ID);
                                }
                            }
                            else
                            {
                                if (usr != null && user.ID != "")
                                {
                                    if (acction == "1")
                                    {
                                        subjecUser.Delete(subjectID, usr.ID);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Index", "ManagerStudents");
        }
    }
}