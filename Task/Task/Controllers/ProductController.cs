using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Task.Models.Entities;
using Task.Models;

namespace Task.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Product s = new Product();
            return View(s);
        }
        [HttpPost]
        public ActionResult Create(Product s)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(s);
                return RedirectToAction("List");
            }
            return View(s);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var s = db.Products.Get(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Product s)
        {
            Database db = new Database();
            db.Products.Edit(s);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Database db = new Database();
            var s = db.Products.Get(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Delete(Product s)
        {
            Database db = new Database();
            db.Products.Delete(s);
            return RedirectToAction("List");
        }
        public ActionResult Yorder()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }
        [HttpGet]
        public ActionResult Ycart(int id)
        {
            Database db = new Database();
            var s = db.Products.Get(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Ycart(Product s)
        {
            Database db = new Database();
            db.Products.CartAdd(s);
            return RedirectToAction("Yorder");
        }
        [HttpGet]
        public ActionResult Cart()
        {
            Database db = new Database();
            var products = db.Products.GetCart();
            return View(products);
        }
        public ActionResult Checkout(Product s)
        {
            Database db = new Database();
            db.Products.OrderAdd(s);
            db.Products.CartDel(s);
            return RedirectToAction("Yorder");
        }
    }
}