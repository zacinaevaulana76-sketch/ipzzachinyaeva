using System;

namespace WarehouseCompanyApp.Models
{
    public class Shipment
    {
        public int ShipmentID { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
    }
}