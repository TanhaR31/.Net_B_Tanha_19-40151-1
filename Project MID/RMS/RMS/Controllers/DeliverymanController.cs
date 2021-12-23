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
    public class DeliverymanController : Controller
    {
        // GET: Deliveryman
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deliveries()
        {
            var p = DeliverymanRepo.GetAllDeliveries();
            return View(p);
        }

        public ActionResult Deliveryman()
        {
            var f = DeliverymanRepo.Deliveryman();
            return View(f);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var p = DeliverymanRepo.Get(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Delivery pd)
        {
            DeliverymanRepo.Edit(pd);
            return RedirectToAction("Deliveries");
        }

        public ActionResult Orders()
        {
            var p = DeliverymanRepo.GetAllOrders();
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string UserName, string Password, string DeliverymanName, string Phone, string Address)
        {
            var db = new RMSEntities();
            if(UserName == "" || Password == "" || DeliverymanName == "" || Phone =="" || Address == "")
            {
                ViewData["Err"] = "Invalid Input";
                RedirectToAction("Create");
            }
            else
            {
                DeliverymanRepo.UserCreate(UserName, Password);
                DeliverymanRepo.DeliverymanCreate(DeliverymanName, Phone, Address);
                db.SaveChanges();
                return RedirectToAction("Deliveryman");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var p = DeliverymanRepo.Update(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Update(DeliverymansDetail pd)
        {
            DeliverymanRepo.Update(pd);
            return RedirectToAction("Deliveryman");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var p = DeliverymanRepo.Update(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(DeliverymansDetail pd)
        {
            var db = new RMSEntities();
            var man = (from p in db.DeliverymansDetails
                           where p.Id == pd.Id
                           select p).FirstOrDefault();
            db.DeliverymansDetails.Remove(man);
            db.SaveChanges();
            var mn = (from p in db.Users
                       where p.Id == man.UserId
                       select p).FirstOrDefault();
            db.Users.Remove(mn);
            db.SaveChanges();
            return RedirectToAction("Deliveryman");
        }

        public ActionResult Free()
        {
            var f = DeliverymanRepo.Free();
            return View(f);
        }
    }
}