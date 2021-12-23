using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Task.Models.Tables;

namespace Task.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; } //table from Table folder
        public Products Carts { get; set; }
        public Products Orders { get; set; }
        public Database()
        {
            string connString = "Data Source=DESKTOP-KA2838Q;Initial Catalog=Task;Integrated Security=True; User ID = sa; Password = QETUOwryip1999*";
            conn = new SqlConnection(connString);
            Products = new Products(conn); //instance
        }
    }
}