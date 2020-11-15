using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
namespace ElearningSubject.Models
{
    public class ReportModel
    {
        public string TeacherName { set; get; }
        public string SubjectName { set; get; }
        public string Quantity { set; get; }
        public ReportModel()
        {

        }
        public List<ReportModel> GetAll()
        {
            List <ReportModel> data = CBO.FillCollection<ReportModel>(DataProvider.Instance.ExecuteReader("sp_ViewReport"));
            return data;
        }
        public List<JsTreeModel> GetAllTreeDeparment()
        {
            List<JsTreeModel> data = CBO.FillCollection<JsTreeModel>(DataProvider.Instance.ExecuteReader("sp_GetDepartmentTree"));
            return data;
        }

        public List<JsTreeModel> GetAllTreeUser(string deptId)
        {
            List<JsTreeModel> data = CBO.FillCollection<JsTreeModel>(DataProvider.Instance.ExecuteReader("sp_GetUserTree", deptId));
            return data;
        }

        public List<JsTreeModel> GetAllTreeSubject(string userId)
        {
            List<JsTreeModel> data = CBO.FillCollection<JsTreeModel>(SqlDataProvider.Instance.ExecuteReader("sp_GetSubjectTree", userId));
            return data;
        }
        public List<JsTreeModel> GetChildrenLesson(string idLesson)
        {
            List<JsTreeModel> data = CBO.FillCollection<JsTreeModel>(SqlDataProvider.Instance.ExecuteReader("sp_GetChildrenLesson", idLesson));
            return data;
        }
    }
}