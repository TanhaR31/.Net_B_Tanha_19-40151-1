using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS.Repositories;
using RMS.Models.EF;
using RMS.Models.VM;
using System.Web.Security;

namespace RMS.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            var db = new RMSEntities();
            User user = UserRepo.Authenticate(UserName, Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                Session["User"] = UserName;
                Session["Id"] = user.Id;
                if(user.Type == "Customer" || user.Type == "Deliveryman")
                {
                    ViewData["Err"] = "You're Not Allowed In This Page";
                    RedirectToAction("Login", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }                
            }
            else
            {
                ViewData["Err"] = "User Name & Password Did Not Match";
                RedirectToAction("Login", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("User");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}