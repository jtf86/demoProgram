using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Mall.Models
{
    public class Product
    {
        private int _id;
        private string _description;

        public Product(string description, int id=0)
        {
            _description = description;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetDescription()
        {
           return _description;
        }

        public static List<Product> GetAll()
        {
            List<Product> allProducts = new List<Product> {};

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM products;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string description = rdr.GetString(1);
                Product newProduct = new Product(description, id);
                allProducts.Add(newProduct);
            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return allProducts;

        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO products (description) VALUES (@description);";

            cmd.Parameters.Add(new MySqlParameter("@description", _description));

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;


            conn.Close();
            if (conn != null) 
            {
                conn.Dispose();
            }

        }
    }
}