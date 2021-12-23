using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Models.Entities
{
    public class Cart
    {
        public int SL { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}