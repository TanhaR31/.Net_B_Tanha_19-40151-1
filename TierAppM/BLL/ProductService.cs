using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BEL;
using AutoMapper;
using DAL;

namespace BLL
{
    public class ProductService
    {
        public static List<ProductVM> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductVM>());
            var mapper = new Mapper(config);
            //IRepository<Product, int> data = DataAccessFactory.ProductDataAccess();
            var data = mapper.Map<List<ProductVM>>(DataAccessFactory.ProductDataAccess().Get());
            return data;
        }

        public static List<string> GetNames()
        {
            var data = (from e in DataAccessFactory.ProductDataAccess().Get()
                        select e.Name).ToList();
            //data = ProductRepo.GetAll().Select(e => e.Name).ToList();
            return data;
        }

        public static void GetAllWithOrder()
        {

        }
    }
}
