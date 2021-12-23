using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS.Repositories;
using RMS.Models.EF;
using RMS.Models.VM;

namespace RMS.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        // GET: Manager

        public ActionResult List()
        {
            var p = ManagersDetailRepo.GetAll();
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var p = ManagersDetailRepo.Get(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(ManagersDetail pd)
        {
            ManagersDetailRepo.Edit(pd);
            return RedirectToAction("List");
        }
    }
}