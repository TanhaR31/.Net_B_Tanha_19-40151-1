using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntroAPIM.Models.EF;

namespace IntroAPIM.Models.VM
{
    public class ProductOrderVM
    {
        public ProductOrderVM()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}