using Core;
using System.Collections.Generic;

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
        public bool Delete(string subject, string user)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_deleteUserSubject", subject, user);
            return result > 0;
        }
        public UserSubject GetSubjectUserData(string subject, string user)
        {
            UserSubject data = CBO.FillObject<UserSubject>(DataProvider.Instance.ExecuteReader("sp_GetSubjectUserData",subject, user));
            return data;
        }
        public UserSubject GetSubjectUserDataEmail(string subject, string user)
        {
            UserSubject data = CBO.FillObject<UserSubject>(DataProvider.Instance.ExecuteReader("sp_GetSubjectUserDataEmail", subject, user));
            return data;
        }
    }
}