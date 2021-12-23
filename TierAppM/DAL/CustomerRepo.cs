using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerRepo : IRepository<Customer, int>
    {
        OMSEntities db;
        public CustomerRepo(OMSEntities db)
        {
            this.db = db;
        }
        public void Add(Customer e)
        {
            db.Customers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Customers.FirstOrDefault(en => en.Id == id);
            db.Customers.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Customer e)
        {
            var p = db.Customers.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(en => en.Id == id);
        }
    }
}
