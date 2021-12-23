using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS.Models.EF;
using RMS.Models.VM;

namespace RMS.Repositories
{
    public class DeliverymanRepo
    {
        static RMSEntities db;
        static DeliverymanRepo()
        {
            db = new RMSEntities();
        }

        public static List<DeliveryVM> GetAllDeliveries()
        {
            var orders = new List<DeliveryVM>();
            foreach (var p in db.Deliveries)
            {
                DeliveryVM pd = new DeliveryVM()
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    CustomerId = p.CustomerId,
                    DeliverymanId = p.DeliverymanId,
                    Status = p.Status
                };
                orders.Add(pd);
            }
            return orders;
        }

        public static List<OrderVM> GetAllOrders()
        {
            var orders = new List<OrderVM>();
            foreach (var p in db.Orders)
            {
                OrderVM pd = new OrderVM()
                {
                    Id = p.Id,
                    CustomerId = p.CustomerId,
                    Status = p.Status,
                    Price = p.Price
                };
                orders.Add(pd);
            }
            return orders;
        }

        public static List<DeliverymanVM> Deliveryman()
        {
            var man = new List<DeliverymanVM>();
            foreach (var p in db.DeliverymansDetails)
            {
                DeliverymanVM d = new DeliverymanVM()
                {
                    Id = p.Id,
                    DeliverymanName = p.DeliverymanName,
                    Phone = p.Phone,
                    Address = p.Address,
                    Status = p.Status,
                    UserId = p.UserId
                };
                man.Add(d);
            }
            return man;
        }

        public static DeliveryVM Get(int id)
        {
            var p = (from pr in db.Deliveries
                     where pr.Id == id
                     select pr).FirstOrDefault();

            DeliveryVM pd = new DeliveryVM()
            {
                Id = p.Id,
                OrderId = p.OrderId,
                CustomerId = p.CustomerId,
                DeliverymanId = p.DeliverymanId,
                Status = p.Status
            };
            return pd;
        }       

        public static void Edit(Delivery pd)
        {
            var delivery = (from p in db.Deliveries
                           where p.Id == pd.Id
                           select p).FirstOrDefault();
            db.Entry(delivery).CurrentValues.SetValues(pd);
            db.Entry(delivery).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            var id = delivery.DeliverymanId;
            var stat = (from s in db.DeliverymansDetails
                        where s.Id == id
                        select s).FirstOrDefault();
            stat.Status = "Busy";
            db.SaveChanges();
        }

        public static DeliverymanVM Update(int id)
        {
            var p = (from pr in db.DeliverymansDetails
                     where pr.Id == id
                     select pr).FirstOrDefault();

            DeliverymanVM pd = new DeliverymanVM()
            {
                Id = p.Id,
                DeliverymanName = p.DeliverymanName,
                Phone = p.Phone,
                Address = p.Address,
                Status = p.Status,
                UserId = p.UserId
            };
            return pd;
        }

        public static void Update(DeliverymansDetail pd)
        {
            var man = (from p in db.DeliverymansDetails
                           where p.Id == pd.Id
                           select p).FirstOrDefault();
            db.Entry(man).CurrentValues.SetValues(pd);
            db.Entry(man).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public static void UserCreate (string UserName, string Password)
        {
            User uu = new User();

            uu.UserName = UserName;
            uu.Password = Password;
            uu.Type = "Deliveryman";
            db.Users.Add(uu);
            db.SaveChanges();
        }

        public static void DeliverymanCreate (string DeliverymanName, string Phone, string Address)
        {
            int id = (from record in db.Users
                      orderby record.Id descending
                      select record.Id).First();

            //string name = (from record in db.Users
            //               orderby record.Id descending
            //               select record.UserName).First();

            DeliverymansDetail dd = new DeliverymansDetail();

            dd.DeliverymanName = DeliverymanName;
            dd.Phone = Phone;
            dd.Address = Address;
            dd.Status = "Free";
            dd.UserId = id;
            db.DeliverymansDetails.Add(dd);
            int v = db.SaveChanges();
        }

        //public static List<DeliverymanVM> Deliveryman()
        //{
        //    var man = new List<DeliverymanVM>();
        //    foreach (var p in db.DeliverymansDetails)
        //    {
        //        DeliverymanVM d = new DeliverymanVM()
        //        {
        //            Id = p.Id,
        //            DeliverymanName = p.DeliverymanName,
        //            Phone = p.Phone,
        //            Address = p.Address,
        //            Status = p.Status,
        //            UserId = p.UserId
        //        };
        //        man.Add(d);
        //    }
        //    return man;
        //}

        public static List<DeliverymanVM> Free()
        {
            var man = new List<DeliverymanVM>();

            var t = (from pr in db.DeliverymansDetails
                     where pr.Status == "Free"
                     select pr).ToList();

            foreach (var p in t)
            {
                DeliverymanVM d = new DeliverymanVM()
                {
                    Id = p.Id,
                    DeliverymanName = p.DeliverymanName,
                    Phone = p.Phone,
                    Address = p.Address,
                    Status = p.Status,
                    UserId = p.UserId
                };
                man.Add(d);
            }
            return man;
        }
    }
}