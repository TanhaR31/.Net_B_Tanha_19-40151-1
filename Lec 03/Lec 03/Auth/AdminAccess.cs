using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lec_03.Models;

namespace Lec_03.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess : AuthorizeAttribute
    {        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var username = httpContext.User.Identity.Name; //authentication er somoy jei user set hoy, seta ekhane pabo
                //httpContext.User.Identity.IsAuthenticated{ GetType } //IsAuthenticated T/F return kore.
                var db = new Database();
                var type = db.Users.GetUserType(username);
                if (type == 1)
                {
                    return true;
                }
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}