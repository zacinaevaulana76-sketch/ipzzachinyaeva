using System;

namespace WarehouseCompanyApp.Models
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public DateTime Date { get; set; }
        public string Supplier { get; set; }
    }
}