using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using System.Text;
using System.Net.Mail;

namespace ElearningSubject.Models
{
    public class Users
    {
        public string ID { set; get; }
        public string Fullname { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Roles { set; get; }
        public DateTime DateCreated { set; get; }
        public string IDDepartment { set; get; }
        public bool Status { set; get; }
        public string StatusName { set; get; }
        public string Department { set; get; }

        public Users()
        {

        }

        public bool Add(Users user)
        {
            user.Password = EncodingPassword(user.Password);
            //int result = DataProvider.Instance.ExecuteNonQuery("sp_addUsers", user.Fullname, user.Email, user.Password, user.DateCreated, user.IDDepartment);
            object obj = DataProvider.Instance.ExecuteNonQueryWithOutput("@id","sp_addUsers",user.Fullname, user.Email, user.Password, user.DateCreated, user.IDDepartment,0);
            return -1 > 0;
        }

        public bool Update(Users user)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("sp_updateUsers", user.Fullname, user.Roles, user.IDDepartment);
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

        public List<Users> GetAll(int id = 0, string status = "")
        {
            List<Users> data = CBO.FillCollection<Users>(DataProvider.Instance.ExecuteReader("sp_getAllUsers", id, status));
            return data;
        }
        public static string EncodingPassword(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));

            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public static bool SendMail(string email, string username)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add(email);
                mail.Subject = "[Reset Password]";
                mail.Body = string.Format("Mật khẩu mới cả tài khoản {0} là: <b>{1}</b>", username, RandomPassword());

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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