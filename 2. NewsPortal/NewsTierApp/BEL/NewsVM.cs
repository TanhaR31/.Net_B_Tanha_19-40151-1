using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NewsVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CtgrId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
    }
}
