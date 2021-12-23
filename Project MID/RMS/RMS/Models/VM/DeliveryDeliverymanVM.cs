using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RMS.Models.EF;

namespace RMS.Models.VM
{
    public class DeliveryDeliverymanVM
    {
        public IEnumerable<DeliveryVM> Deliveries { get; set; }
        public IEnumerable<DeliverymanVM> DeliverymanDetails { get; set; }

    }
}