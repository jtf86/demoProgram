using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Mall.Models
{
    public class Store
    {
       private int _id;
       private string _name;
       private int _productId;
       private int _floorId;

       public Store(string name, int floorId, int productId, int id=0)
       {
           _name = name;
           _floorId = floorId;
           _productId = productId;
           _id = id;
       }

       public int GetId()
       {
           return _id;
       }
       public string GetName()
       {
           return _name;
       }
       public int GetFloorId()
       {
           return _floorId;
       }
       public int GetProductId()
       {
           return _productId;
       }

        public static List<Store> GetAll()
        {
            List<Store> allStores = new List<Store> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stores;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                int floorId = rdr.GetInt32(3);
                int productId = rdr.GetInt32(2);
                string name = rdr.GetString(1);
                Store newStore = new Store(name, floorId, productId, id);
                allStores.Add(newStore);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStores;

        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stores (name, product_id, floor_id) VALUES (@name, @productId, @floorId);";

            cmd.Parameters.Add(new MySqlParameter("@name", _name));
            cmd.Parameters.Add(new MySqlParameter("@floorId", _floorId));
            cmd.Parameters.Add(new MySqlParameter("@productId", _productId));

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public Product GetProduct()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM products WHERE id = @productId;";

            cmd.Parameters.Add(new MySqlParameter("@productId", _productId));

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string description = "";
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
                description = rdr.GetString(1);
            }

            Product foundProduct = new Product(description, id);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundProduct;
        }
    }
}