using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Models.VM
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
    }
}