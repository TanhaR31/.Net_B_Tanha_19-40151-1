using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RMS.Models.EF;
using RMS.Models.VM;

namespace RMS.Repositories
{
    public class UserRepo
    {
        static RMSEntities db;
        static UserRepo()
        {
            db = new RMSEntities();
        }
        public static User Authenticate(string username, string password)
        {
            //User user = null;
            User user = (from p in db.Users
                           where p.UserName == username && p.Password == password
                           select p).FirstOrDefault();
            return user;
        }
    }
}