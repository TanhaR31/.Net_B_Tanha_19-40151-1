using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Lec_03.Models;
using Lec_03.Models.Entities;
using Lec_03.Auth;

namespace Lec_03.Controllers
{
    //[Authorize]
    [AdminAccess] //Sob action authorize korte hobe. Nahole dekha jabe na
    public class StudentController : Controller
    {
        // GET: Student
        //[Authorize]
        [AllowAnonymous] //opposite of [Authorize]. Jei action er age eta thakbe segula authentication chara dekhte parbe
        public ActionResult Index()
        {
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KA2838Q;Initial Catalog=UMSS;Integrated Security=True; User ID = sa; Password = QETUOwryip1999*");
            //conn.Open();
            //string query = "select * from Students";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //SqlDataReader reader = cmd.ExecuteReader();
            //List<Student> students = new List<Student>();
            //while (reader.Read())
            //{
            //    Student s = new Student()
            //    {
            //        Id = reader.GetInt32(reader.GetOrdinal("Id")),//db er column index number int hisebe recieve kore getInt32, getString esb function. 0 to n                                                                     
            //                                                      //GetOrdinal rcv kore param e deowa column name & return kore ekta index
            //                                                      //and sei index er value ta rcv kortese finally variable
            //        Name = reader.GetString(reader.GetOrdinal("Name")),
            //        Dob = reader.GetString(reader.GetOrdinal("Dob")),
            //        Gender = reader.GetString(reader.GetOrdinal("Gender")),
            //        Cgpa = (float)reader.GetDouble(reader.GetOrdinal("Cgpa"))
            //    };
            //    students.Add(s);
            //}
            //conn.Close();

            //var logged = Session["Logged"];
            //if (logged == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            Database db = new Database(); //db er instance create hocche jate db connect hoy
            var students = db.Students.Get();
            return View(students);
            //list ta index view er sathe bind korte hobe
        }

        [HttpGet]
        public ActionResult Create()
        {
            Student s = new Student();
            return View(s);
            //return View();
        }

        [HttpPost] //right validation hole ei function e request hit korbe r nahole agerta. get req
        public ActionResult Create(Student s) //same page e submit korte chacchi, jate user vul input dile error msg dekhano jay
        {
            if (ModelState.IsValid)//for validation. Student class e giye rules check korbe
            {
                //string connString = @"Server=DESKTOP-KA2838Q; Database=UMSS; Integrated Security=true; User Id=sa; Password=QETUOwryip1999*";
                //SqlConnection conn = new SqlConnection("connString");
                //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KA2838Q;Initial Catalog=UMSS;Integrated Security=True; User ID = sa; Password = QETUOwryip1999*");
                //conn.Open();
                ////string query = "select * from Students";        
                //string query = String.Format("insert into Students values ('{0}','{1}','{2}',0.0)", s.Name, s.Dob, s.Gender);
                //SqlCommand cmd = new SqlCommand(query, conn);
                ////SqlDataReader reader = cmd.ExecuteReader(); //select er jonno execute
                //int r = cmd.ExecuteNonQuery(); //insert er jonno execute nonquery          
                //conn.Close();
                /*while (reader.Read())
                {
                    var a = reader.GetString(reader.GetOrdinal("Name"));
                }*/
                Database db = new Database();
                db.Students.Create(s); //form theke jei info pabo seta s diye pass kore deowa hobe Students cls e.
                return RedirectToAction("Index");//user info valid hole index page e niye jabe.
            }
            return View(s);//eta return hobe jokhon info valid na
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var s = db.Students.Get(id);
            return View(s);
        }
    }
}
