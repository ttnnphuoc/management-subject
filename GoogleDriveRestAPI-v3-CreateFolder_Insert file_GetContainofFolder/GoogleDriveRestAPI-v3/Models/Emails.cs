using Core;
using System.Collections.Generic;

namespace ElearningSubject.Models
{
    public class Emails
    {
        public string Email { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public Emails()
        {

        }

        public Emails GetEmailByStatus(string em = "", string status = "")
        {
            Emails email = CBO.FillObject<Emails>(DataProvider.Instance.ExecuteReader("sp_getEmailByStatus",em,status));
            return email;
        }

        public List<Emails> GetListEmail()
        {
            List<Emails> data = CBO.FillCollection<Emails>(DataProvider.Instance.ExecuteReader("sp_getListEmail"));
            return data;
        }
    }
}