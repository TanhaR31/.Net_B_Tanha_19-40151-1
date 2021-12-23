using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS.Models.EF;
using RMS.Models.VM;

namespace RMS.Repositories
{
    public class ManagersDetailRepo
    {
        static RMSEntities db;
        static ManagersDetailRepo()
        {
            db = new RMSEntities();
        }

        public static List<ManagersDetailVM> GetAll()
        {
            var managers = new List<ManagersDetailVM>();
            foreach (var p in db.ManagersDetails)
            {
                ManagersDetailVM pd = new ManagersDetailVM()
                {
                    Id = p.Id,
                    ManagerName = p.ManagerName,
                    Phone = p.Phone,
                    Address = p.Address,
                    UserId = p.UserId
                };
                managers.Add(pd);
            }
            return managers;
        }

        public static ManagersDetailVM Get(int id)
        {
            var p = (from pr in db.ManagersDetails
                     where pr.Id == id
                     select pr).FirstOrDefault();

            ManagersDetailVM pd = new ManagersDetailVM()
            {
                Id = p.Id,
                ManagerName = p.ManagerName,
                Phone = p.Phone,
                Address = p.Address,
                UserId = p.UserId
            };
            return pd;
        }

        public static void Edit(ManagersDetail pd)
        {
            var mngr = (from p in db.ManagersDetails
                           where p.Id == pd.Id
                           select p).FirstOrDefault();
            db.Entry(mngr).CurrentValues.SetValues(pd);
            db.Entry(mngr).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
    }
}