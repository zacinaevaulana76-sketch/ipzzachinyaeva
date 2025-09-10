namespace WarehouseCompanyApp.Models
{
    public class ReceiptItem
    {
        public int ReceiptItemID { get; set; }
        public int ReceiptID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}