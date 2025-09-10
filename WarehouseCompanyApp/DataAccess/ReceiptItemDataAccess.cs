using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.DataAccess
{
    public class ReceiptItemDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<ReceiptItem> GetAllReceiptItems()
        {
            var items = new List<ReceiptItem>();
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ReceiptItemID, ReceiptID, ProductID, Quantity FROM ReceiptItems";
                SqlCommand cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new ReceiptItem
                    {
                        ReceiptItemID = reader.GetInt32(0),
                        ReceiptID = reader.GetInt32(1),
                        ProductID = reader.GetInt32(2),
                        Quantity = reader.GetInt32(3)
                    });
                }
            }
            return items;
        }

        public void AddReceiptItem(ReceiptItem item)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO ReceiptItems (ReceiptID, ProductID, Quantity) VALUES (@ReceiptID, @ProductID, @Quantity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReceiptID", item.ReceiptID);
                cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateReceiptItem(ReceiptItem item)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE ReceiptItems SET ReceiptID=@ReceiptID, ProductID=@ProductID, Quantity=@Quantity WHERE ReceiptItemID=@ReceiptItemID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReceiptID", item.ReceiptID);
                cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@ReceiptItemID", item.ReceiptItemID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteReceiptItem(int receiptItemId)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM ReceiptItems WHERE ReceiptItemID=@ReceiptItemID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReceiptItemID", receiptItemId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}