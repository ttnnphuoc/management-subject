using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
namespace ElearningSubject.Models
{
    public class Departments
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool Status { set; get; }
        public string NameStatus { set; get; }
        public Departments()
        {

        }

        public bool Add(Departments dep)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_addDepartment", dep.Name, dep.Description);
            return result > 0;
        }
        
        public List<Departments> GetAll(int id=0, string status= "")
        {
            List<Departments> data = CBO.FillCollection<Departments>(DataProvider.Instance.ExecuteReader("sp_getAllDeparment", id, status));
            return data;
        }

        public bool Update(Departments dep)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateDepartment",dep.ID, dep.Name, dep.Description, dep.Status);
            return result > 0;
        }

        public bool Delete(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_deleteDepartment", id);
            return result > 0;
        } 
    }
}