using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Lec_03.Models.Tables;

namespace Lec_03.Models
{
    public class Database //Db class e tables gula thakbe. So tables er jonno jei class gula create kora ache segular instance Db cls e thakbe.
    {
        SqlConnection conn;
        public Students Students { get; set; } //reference type val. constructor eder k null val diye initiate korbe
        public Courses Courses { get; set; }
        public Departments Departments { get; set; }
        public Users Users { get; set; }
        public Database() //constructor sob field, property k default val diye initiate kore
        {
            string connString = "Data Source=DESKTOP-KA2838Q;Initial Catalog=UMSS;Integrated Security=True; User ID = sa; Password = QETUOwryip1999*";
            conn = new SqlConnection(connString);
            Students = new Students(conn); //instance create korlam jate kore db constructor null val initiate na kore
            Courses = new Courses();
            Departments = new Departments();
            Users = new Users(conn);
        }
    }
}