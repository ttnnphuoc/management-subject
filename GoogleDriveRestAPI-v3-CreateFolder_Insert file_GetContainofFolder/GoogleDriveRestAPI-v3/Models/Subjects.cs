﻿using System.Collections.Generic;
using Core;
namespace ElearningSubject.Models
{
    public class Subjects
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool Status { set; get; }
        public string NameStatus { set; get; }
        public string SoLuong { set; get; }
        public Subjects()
        {
            
        }

        public bool Add(string id,string name, string description)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_addSubjects",id, name,description);
            return result > 0;
        }

        public bool Update(Subjects sub)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateSubjects", sub.ID, sub.Name, sub.Description,sub.Status);
            return result > 0;
        }
        public bool UpdateChildren(string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateSubjectsParent", id);
            return result > 0;
        }
        public bool Delete(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_deleteSubjects", id);
            return result > 0;
        }
        

        public List<JsTreeModel> GetAllTreeFolder(string id = "",string status = "")
        {
            List<JsTreeModel> data = CBO.FillCollection<JsTreeModel>(DataProvider.Instance.ExecuteReader("sp_getAllSubjects", id, status));
            return data;
        }
        public Subjects GetSubjectById(string id = "", string status = "")
        {
            Subjects sub = CBO.FillObject<Subjects>(DataProvider.Instance.ExecuteReader("sp_getSubjectById", id,status));
            return sub;
        }
        public List<Subjects> GetListSubjectByUser(string user)
        {
            List<Subjects> data = CBO.FillCollection<Subjects>(DataProvider.Instance.ExecuteReader("sp_getSubjectByUser",user));
            return data;
        }

        public List<Subjects> GetQuantityLessonBySubject()
        {
            List<Subjects> data = CBO.FillCollection<Subjects>(DataProvider.Instance.ExecuteReader("sp_getQuantityLessonBySubject"));
            return data;
        }
    }
}