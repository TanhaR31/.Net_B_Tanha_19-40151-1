using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS.Models.EF;
using RMS.Models.VM;

namespace RMS.Repositories
{
    public class ProductRepo
    {
        static RMSEntities db;
        static ProductRepo()
        {
            db = new RMSEntities();
        }

        public static ProductVM Get(int id)
        {
            var p = (from pr in db.Products
                     where pr.Id == id
                     select pr).FirstOrDefault();

            ProductVM pd = new ProductVM()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                Category = p.Category
            };
            return pd;
        }
        public static List<ProductVM> GetAll()
        {
            var products = new List<ProductVM>();
            foreach (var p in db.Products)
            {
                ProductVM pd = new ProductVM()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                    Category = p.Category
                };
                products.Add(pd);
            }
            return products;
        }
        public static void Edit(Product pd)
        {
            var product = (from p in db.Products
                           where p.Id == pd.Id
                           select p).FirstOrDefault();
            db.Entry(product).CurrentValues.SetValues(pd);
            db.Entry(product).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
    }
}