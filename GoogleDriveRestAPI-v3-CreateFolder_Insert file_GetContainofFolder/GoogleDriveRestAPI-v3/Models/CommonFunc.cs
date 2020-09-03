using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningSubject.Models
{
    public class CommonFunc
    {
        public static bool IsNotLogin(string user)
        {
            if (string.IsNullOrEmpty(user))
                return true;
            return false;
        }
    }
}