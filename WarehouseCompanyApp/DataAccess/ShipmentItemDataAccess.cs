using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.DataAccess
{
    public class ShipmentItemDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<ShipmentItem> GetAllShipmentItems()
        {
            var items = new List<ShipmentItem>();
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ShipmentItemID, ShipmentID, ProductID, Quantity FROM ShipmentItems";
                SqlCommand cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new ShipmentItem
                    {
                        ShipmentItemID = reader.GetInt32(0),
                        ShipmentID = reader.GetInt32(1),
                        ProductID = reader.GetInt32(2),
                        Quantity = reader.GetInt32(3)
                    });
                }
            }
            return items;
        }

        public void AddShipmentItem(ShipmentItem item)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO ShipmentItems (ShipmentID, ProductID, Quantity) VALUES (@ShipmentID, @ProductID, @Quantity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShipmentID", item.ShipmentID);
                cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateShipmentItem(ShipmentItem item)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE ShipmentItems SET ShipmentID=@ShipmentID, ProductID=@ProductID, Quantity=@Quantity WHERE ShipmentItemID=@ShipmentItemID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShipmentID", item.ShipmentID);
                cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@ShipmentItemID", item.ShipmentItemID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteShipmentItem(int shipmentItemId)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM ShipmentItems WHERE ShipmentItemID=@ShipmentItemID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShipmentItemID", shipmentItemId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}