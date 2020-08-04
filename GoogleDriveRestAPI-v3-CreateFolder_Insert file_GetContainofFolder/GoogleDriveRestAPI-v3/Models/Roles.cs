using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
namespace ElearningSubject.Models
{
    public class Roles
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool Status { set; get; }
        public string NameStatus { set; get; }
        public Roles()
        {
            
        }

        public bool Add(string name, string description)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_addRoles",name,description);
            return result > 0;
        }

        public bool Update(Roles role)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateRoles", role.ID, role.Name,role.Description,role.Status);
            return result > 0;
        }

        public bool Delete(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_deleteRoles", id);
            return result > 0;
        }
        

        public List<Roles> GetAll(int id = 0,string status = "")
        {
            List<Roles> roles = CBO.FillCollection<Roles>(DataProvider.Instance.ExecuteReader("sp_getAllRoles", id, status));
            return roles;
        }
    }
}