using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace ElearningSubject.Models
{
    public class UserSubject
    {
        public string IDSubject { set; get; }
        public string IDUsers { set; get; }
        public string Status { set; get; }
        public UserSubject()
        {

        }
        public bool Add(string subject, string user)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_addUserSubject", subject, user, 1);
            return result > 0;
        }
        
    }
}