using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
namespace ElearningSubject.Models
{
    public class Comments
    {
        public int ID { set; get; }
        public string SUBJECTID { set; get; }
        public string LESSONID { set; get; }
        public string COMMENT { set; get; }
        public string USERID { set; get; }
        public DateTime DATECREATE { set; get; }
        public string Date
        {
            set { }
            get
            {
                return this.DATECREATE.ToString("dd/MM/yyyy");
            }
        }
        public string Time
        {
            set { }
            get
            {
                return this.DATECREATE.ToString("hh:mm");
            }
        }
        public string Fullname { set; get; }
        public Comments()
        {

        }
        public Comments(int id, string subject, string lesson, string comment, string user, DateTime date)
        {
            this.ID = id;
            this.SUBJECTID = subject;
            this.LESSONID = lesson;
            this.COMMENT = comment;
            this.USERID = user;
            this.DATECREATE = date;
        }
        public bool Add(Comments cmt)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_AddComment", cmt.SUBJECTID, cmt.LESSONID, cmt.COMMENT, cmt.USERID);
            return result > 0;
        }
        public List<Comments> GetListComment(Comments cmt)
        {
            List<Comments> list = CBO.FillCollection<Comments>(DataProvider.Instance.ExecuteReader("sp_GetAllComment", cmt.SUBJECTID, cmt.LESSONID));
            return list;
        }
    }
}