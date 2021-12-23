using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS.Models.EF;

namespace RMS.Models.VM
{
    public class DeliveryVM
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> DeliverymanId { get; set; }
        public string Status { get; set; }

        public virtual CustomersDetail CustomersDetail { get; set; }
        public virtual DeliverymansDetail DeliverymansDetail { get; set; }
        public virtual Order Order { get; set; }
    }
}