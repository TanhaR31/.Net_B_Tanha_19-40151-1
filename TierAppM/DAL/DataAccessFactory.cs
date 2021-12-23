using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        //Abstraction
        //jokhon kono class kono interface k implement korbe, sei interface er moddhe tar instance pass kora jabe
        static OMSEntities db;
        static DataAccessFactory()
        {
            db = new OMSEntities();
        }
        public static IRepository<Product, int> ProductDataAccess()
        {
            return new ProductRepo(db);
        }
        public static IRepository<Customer, int> CustomerDataAccess()
        {
            return new CustomerRepo(db);
        }
    }
}
