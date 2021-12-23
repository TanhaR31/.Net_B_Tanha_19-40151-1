using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lec_03.Models.Entities
{
    public class Course
    {
        public int Id { set; get; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}