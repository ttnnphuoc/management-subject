using System;
using System.Collections.Generic;
using Core;
using System.Text;
using System.Net.Mail;
using System.Security.Cryptography;

namespace ElearningSubject.Models
{
    public class Users
    {
        public string ID { set; get; }
        public string Fullname { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Roles { set; get; }
        public string RolesName { set; get; }
        public DateTime DateCreated { set; get; }
        public string IDDepartment { set; get; }
        public bool Status { set; get; }
        public string NameStatus { set; get; }
        public string Department { set; get; }

        public Users()
        {

        }

        public bool Add(Users user)
        {
            user.Password = EncodingPassword(user.Password);
            int result = DataProvider.Instance.ExecuteNonQuery("sp_addUsers", user.Fullname, user.Email, user.Password, user.DateCreated, user.IDDepartment, user.Roles);
            return result > 0;
        }

        public bool Update(Users user)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateUsers",user.ID, user.Fullname, user.IDDepartment,-1);
            return result > 0;
        }

        public bool Delete(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_deleteUsers", id);
            return result > 0;
        }

        public Users Login(string username, string password)
        {
            password = EncodingPassword(password);
            Users user = CBO.FillObject<Users>(DataProvider.Instance.ExecuteReader("sp_login", username, password));

            return user;
        }

        public bool ChangePassword(string username, string password)
        {
            password = EncodingPassword(password);
            int result = DataProvider.Instance.ExecuteNonQuery("sp_changePassword", username, password);
            return result > 0;
        }

        public List<Users> GetAll(string id = "0", string status = "",string department = "")
        {
            List<Users> data = CBO.FillCollection<Users>(DataProvider.Instance.ExecuteReader("sp_getAllUsers", id, status,department));
            return data;
        }
        public List<Users> GetAllByRole(string id = "0", string status = "", string department = "", string role = "")
        {
            List<Users> data = CBO.FillCollection<Users>(DataProvider.Instance.ExecuteReader("sp_getAllUsersByRole", id, status, department,role));
            return data;
        }

        public bool UpdatePermission(Users user)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updatePermission", user.ID, user.IDDepartment, user.Roles, user.Status);
            return result > 0;
        }
        public static string EncodingPassword(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
        
        public bool SendMail(string email)
        {
            try
            {
                Emails emailCls = new Emails();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                Emails em = emailCls.GetEmailByStatus("","1");

                mail.From = new MailAddress(em.Email);
                mail.To.Add(email);
                mail.Subject = "[QUÊN MẬT KHẨU]";
                string password = RandomPassword();
                mail.Body = string.Format(@"Mật khẩu mới cả tài khoản {0} là: <b>{1}</b> <br/>
                            <b>Vui lòng đăng nhập và đổi mật khẩu mới.</b>", email, password);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(em.Email, em.Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                ChangePassword(email, password);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public Users GetUserByEmail(string email)
        {
            Users usr = CBO.FillObject<Users>(DataProvider.Instance.ExecuteReader("sp_GetUserByEmail", email));
            return usr;
        }
        private static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}