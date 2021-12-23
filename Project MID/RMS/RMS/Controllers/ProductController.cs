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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var p = ProductRepo.GetAll();
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            var db = new RMSEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var p = ProductRepo.Get(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product pd)
        {
            ProductRepo.Edit(pd);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var p = ProductRepo.Get(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(Product pd)
        {
            var db = new RMSEntities();
            var product = (from p in db.Products
                           where p.Id == pd.Id
                           select p).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}