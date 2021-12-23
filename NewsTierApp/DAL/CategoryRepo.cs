using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CategoryRepo : IRepository<Category, int>
    {
        NPEntities db;
        public CategoryRepo(NPEntities db)
        {
            this.db = db;
        }

        public void Add(Category e)
        {
            db.Categories.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Categories.FirstOrDefault(en => en.Id == id);
            db.Categories.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Category e)
        {
            var p = db.Categories.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(en => en.Id == id);
        }
    }
}
