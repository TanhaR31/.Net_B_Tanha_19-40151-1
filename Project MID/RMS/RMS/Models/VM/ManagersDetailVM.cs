using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Models.VM
{
    public class ManagersDetailVM
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}