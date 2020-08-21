using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public Subjects()
        {
            
        }

        public bool Add(string id,string name, string description)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_addSubjects",id, name,description);
            return result > 0;
        }

        public bool Update(Roles role)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateSubjects", role.ID, role.Name,role.Description,role.Status);
            return result > 0;
        }

        public bool Delete(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_deleteSubjects", id);
            return result > 0;
        }
        

        public List<JsTreeModel> GetAll(string id = "",string status = "")
        {
            List<JsTreeModel> data = CBO.FillCollection<JsTreeModel>(DataProvider.Instance.ExecuteReader("sp_getAllSubjects", id, status));
            return data;
        }
    }
}