using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningSubject.Models
{
    public class Users
    {
        public string Id { set; get; }
        public string Fullname { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string[] Role { set; get; }
        public DateTime DateCreated { set; get; }
        public string IDDepartment { set; get; }
    }
}