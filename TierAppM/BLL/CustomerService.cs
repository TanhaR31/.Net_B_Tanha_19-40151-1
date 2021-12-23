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
    public class CustomerService
    {
        public static List<CustomerVM> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerVM>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CustomerVM>>(DataAccessFactory.CustomerDataAccess().Get());
            return data;
        }
    }
}
