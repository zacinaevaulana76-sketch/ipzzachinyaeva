namespace WarehouseCompanyApp.Models
{
    public class ShipmentItem
    {
        public int ShipmentItemID { get; set; }
        public int ShipmentID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}