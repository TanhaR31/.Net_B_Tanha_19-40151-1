using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsRepo : IRepository<Newss, int>
    {
        NPEntities db;
        public NewsRepo(NPEntities db)
        {
            this.db = db;
        }
        public void Add(Newss e)
        {
            db.Newsses.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Newsses.FirstOrDefault(en => en.Id == id);
            db.Newsses.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Newss e)
        {
            var p = db.Newsses.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Newss> Get()
        {
            return db.Newsses.ToList();
        }

        public Newss Get(int id)
        {
            return db.Newsses.FirstOrDefault(en => en.Id == id);
        }
    }
}
