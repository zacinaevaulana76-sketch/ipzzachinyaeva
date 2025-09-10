using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.DataAccess
{
    public class ShipmentDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Shipment> GetAllShipments()
        {
            var shipments = new List<Shipment>();
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ShipmentID, Date, Customer FROM Shipments";
                SqlCommand cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    shipments.Add(new Shipment
                    {
                        ShipmentID = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Customer = reader.IsDBNull(2) ? "" : reader.GetString(2)
                    });
                }
            }
            return shipments;
        }

        public void AddShipment(Shipment shipment)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Shipments (Date, Customer) VALUES (@Date, @Customer)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", shipment.Date);
                cmd.Parameters.AddWithValue("@Customer", shipment.Customer ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateShipment(Shipment shipment)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Shipments SET Date=@Date, Customer=@Customer WHERE ShipmentID=@ShipmentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", shipment.Date);
                cmd.Parameters.AddWithValue("@Customer", shipment.Customer ?? "");
                cmd.Parameters.AddWithValue("@ShipmentID", shipment.ShipmentID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteShipment(int shipmentId)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Shipments WHERE ShipmentID=@ShipmentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShipmentID", shipmentId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}