using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Task.Models.Entities;

namespace Task.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(Product s)
        {
            conn.Open();
            string query = String.Format("insert into Products values ('{0}','{1}','{2}','{3}')", s.Name, s.Description, s.Quantity, s.Price);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Product> Get() //all products
        {
            conn.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product s = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price"))
                };
                products.Add(s);
            }
            conn.Close();
            return products;
        }
        public Product Get(int id) //specific product
        {
            conn.Open();
            string query = String.Format("Select * from Products where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product s = null;
            while (reader.Read())
            {
                s = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price"))
                };
            }
            conn.Close();
            return s;
        }
        public void Edit(Product s)
        {
            conn.Open();
            string query = String.Format("Update Products set Name='{0}', Description='{1}', Quantity='{2}', Price='{3}' where Id ='{4}'", s.Name, s.Description, s.Quantity, s.Price, s.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(Product s)
        {
            conn.Open();
            string query = String.Format("Delete From Products where Id ='{0}'", s.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void CartAdd(Product s)
        {
            conn.Open();
            string query = String.Format("insert into Carts values ('{0}','{1}','{2}','{3}','{4}')", s.Id, s.Name, s.Description, s.Quantity, s.Price);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Product> GetCart()
        {
            conn.Open();
            string query = "select * from Carts";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                double p = 0;
                Product s = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("Price"))
                };
                p = s.Quantity * s.Price;
                products.Add(s);
            }
            conn.Close();
            return products;
        }
        public void OrderAdd(Product s)
        {
            conn.Open();
            string query = String.Format("insert into Orders values ('{0}','{1}','{2}','{3}','{4}')", s.Id, s.Name, s.Description, s.Quantity, s.Price);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void CartDel(Product s)
        {
            conn.Open();
            string query = String.Format("Delete From Carts");
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}