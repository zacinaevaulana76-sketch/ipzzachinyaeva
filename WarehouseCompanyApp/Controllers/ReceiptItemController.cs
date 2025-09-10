using System.Collections.Generic;
using WarehouseCompanyApp.DataAccess;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.Controllers
{
    public class ReceiptItemController
    {
        private ReceiptItemDataAccess dataAccess = new ReceiptItemDataAccess();

        public List<ReceiptItem> GetAllReceiptItems() => dataAccess.GetAllReceiptItems();
        public void AddReceiptItem(ReceiptItem item) => dataAccess.AddReceiptItem(item);
        public void UpdateReceiptItem(ReceiptItem item) => dataAccess.UpdateReceiptItem(item);
        public void DeleteReceiptItem(int receiptItemId) => dataAccess.DeleteReceiptItem(receiptItemId);
    }
}