using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.DataAccess
{
    public class ReceiptDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Receipt> GetAllReceipts()
        {
            var receipts = new List<Receipt>();
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ReceiptID, Date, Supplier FROM Receipts";
                SqlCommand cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    receipts.Add(new Receipt
                    {
                        ReceiptID = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Supplier = reader.IsDBNull(2) ? "" : reader.GetString(2)
                    });
                }
            }
            return receipts;
        }

        public void AddReceipt(Receipt receipt)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Receipts (Date, Supplier) VALUES (@Date, @Supplier)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", receipt.Date);
                cmd.Parameters.AddWithValue("@Supplier", receipt.Supplier ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateReceipt(Receipt receipt)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Receipts SET Date=@Date, Supplier=@Supplier WHERE ReceiptID=@ReceiptID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", receipt.Date);
                cmd.Parameters.AddWithValue("@Supplier", receipt.Supplier ?? "");
                cmd.Parameters.AddWithValue("@ReceiptID", receipt.ReceiptID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteReceipt(int receiptId)
        {
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Receipts WHERE ReceiptID=@ReceiptID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReceiptID", receiptId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}