using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntroAPIM.Models.EF;
using IntroAPIM.Models.VM;
using AutoMapper;

namespace IntroAPIM.Controllers
{
    public class ProductController : ApiController
    {
        /*
        public List<ProductVM> Get()
        {
            OMSEntities db = new OMSEntities();

            var data = new List<ProductVM>();
            foreach (var e in db.Products)
            {
                //var p = new ProductVM()
                //{
                //    Id = e.Id,
                //    Name = e.Name,
                //    Price = e.Price
                //};
                //data.Add(p);
                data.Add(new ProductVM() { Id = e.Id, Name = e.Name, Price = e.Price });
            }
            return data;
        }
        */

        /*
          wont run. cz product er jonno orderDetails table e giye sekhane abar product pabe.
          & ekta self loop e enter korbe.
          fk na thakle run hoto
        */
        //public List<Product> GetA() //VM use na kore direct EF usage
        //{
        //    OMSEntities db = new OMSEntities();
        //    return db.Products.ToList();
        //}

        //public void Post(ProductVM p)
        //{
        //}

        //Custom API
        [Route("api/product/pnames")]
        [HttpGet] //sudhu get er jonno response korbe
        public List<string> PName()
        {
            OMSEntities db = new OMSEntities();

            //db.Products.Select('')

            var data = (from e in db.Products
                       select e.Name).ToList();
            return data;
        }

        [Route("api/product/pnames/{id}")]
        [HttpGet] //sudhu get er jonno response korbe
        public string PName(int id)
        {
            OMSEntities db = new OMSEntities();

            var data = (from e in db.Products
                        where e.Id == id
                        select e.Name).FirstOrDefault();
            return data;
        }

        public List<ProductVM> Get()
        {
            OMSEntities db = new OMSEntities();

            //mapper ekta obj theke arekta obj e convert kore
            //property same hote hobe (Id, Name, ..)
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductVM>()); //product theke productvm e convert hobe
            var mapper = new Mapper(config); //mapper instance
            var data = mapper.Map<List<ProductVM>>(db.Products.ToList()); //<kishe convert hobe>(kake convert korbe)
            return data;
        }

        public void Post(ProductVM p) //db te product pathabo
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductVM, Product>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Product>(p);
            OMSEntities db = new OMSEntities();
            db.Products.Add(data);
            db.SaveChanges(); 
        }
    }
}
