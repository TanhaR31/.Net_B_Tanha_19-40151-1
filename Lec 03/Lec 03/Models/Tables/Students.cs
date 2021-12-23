using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lec_03.Models.Entities;
using System.Data.SqlClient;

namespace Lec_03.Models.Tables
{
    public class Students //Db er table er name class
                          //public function thakbe ei cls e. Db er operation gulo ekhane hobe.
                          //Db class theke query run korbo ei cls e.
    {
        SqlConnection conn;
        public Students(SqlConnection conn) //only by passing SqlConnection we can create Student instance
        {
            this.conn = conn;
        }
        public void Create(Student s)
        {
            conn.Open();       
            string query = String.Format("insert into Students values ('{0}','{1}','{2}',0.0)", s.Name, s.Dob, s.Gender);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery(); //insert er jonno execute nonquery          
            conn.Close();
        }
        public List<Student> Get() //all students
        {
            conn.Open();
            string query = "select * from Students";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student s = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),//db er column index number int hisebe recieve kore getInt32, getString esb function. 0 to n                                                                     
                                                                  //GetOrdinal rcv kore param e deowa column name & return kore ekta index
                                                                  //and sei index er value ta rcv kortese finally variable
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                    Cgpa = (float)reader.GetDouble(reader.GetOrdinal("Cgpa"))
                };
                students.Add(s);
            }
            conn.Close();
            return students;
        }
        public Student Get(int id) //specific student
        {
            conn.Open();
            string query = String.Format("select * from Students where Id ={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Student s = null; //while condition satisfied hole student er instance create hobe, otherwise na. So satisfied na hole jate null dekhay
            while (reader.Read())
            {
                s = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),                                                                                                                                    
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetString(reader.GetOrdinal("Dob")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                    Cgpa = (float)reader.GetDouble(reader.GetOrdinal("Cgpa"))
                };
            }
            conn.Close();
            return s;
        }
    }
}
