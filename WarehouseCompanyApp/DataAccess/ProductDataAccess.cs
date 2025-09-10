using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.DataAccess
{
    public class ProductDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ProductID, Name, Description, Category, Price FROM Products";
                SqlCommand cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Price = reader.GetDecimal(4)
                    });
                }
            }
            return products;
        }

        public void AddProduct(Product product)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Products (Name, Description, Category, Price) VALUES (@Name, @Description, @Category, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description ?? "");
                cmd.Parameters.AddWithValue("@Category", product.Category ?? "");
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Products SET Name=@Name, Description=@Description, Category=@Category, Price=@Price WHERE ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description ?? "");
                cmd.Parameters.AddWithValue("@Category", product.Category ?? "");
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Products WHERE ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}