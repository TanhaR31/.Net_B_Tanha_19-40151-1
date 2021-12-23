using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Models.VM
{
    public class UserVM
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}