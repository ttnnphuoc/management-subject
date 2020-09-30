using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using System.Text;
using System.Net.Mail;

namespace ElearningSubject.Models
{
    public class Lessons
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public string Video { set; get; }
        public string PdfFile { set; get; }
        public string PPTFile { set; get; }
        public string WordFile { set; get; }
        public string IDSubject { set; get; }
        public string Status { set; get; }
        public string StatusName { set; get; }
        public DateTime DateCreated { set; get; }
        public string Description { set; get; }

        public Lessons()
        {

        }

        public bool Add(Lessons lesson)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_addLessons", lesson.ID, lesson.Name, lesson.Video, lesson.PdfFile,lesson.PPTFile, lesson.WordFile,lesson.IDSubject,lesson.Description);
            return result > 0;
        }
        public List<JsTreeModel> GetLessonBySubject(string id)
        {
            List<JsTreeModel> data = CBO.FillCollection<JsTreeModel>(DataProvider.Instance.ExecuteReader("sp_getLessonBySubject",id));
            return data;
        }

        public bool Update(Lessons lesson)
        {
            //int result = DataProvider.Instance.ExecuteNonQuery("sp_updateUsers",user.ID, user.Fullname, user.IDDepartment,-1);
            return true;
        }

        public bool Delete(string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_deleteLessons", id);
            return result > 0;
        }

        public List<Lessons> GetAll(string id = "", string status = "",string subject = "")
        {
            List<Lessons> data = CBO.FillCollection<Lessons>(DataProvider.Instance.ExecuteReader("sp_getAllLessons", id, status, subject));
            return data;
        }

        public bool UpdateFileID(string fieldName, string value, string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateFileIDLesson", fieldName, value, id);
            return result > 0;
        }
    }
}