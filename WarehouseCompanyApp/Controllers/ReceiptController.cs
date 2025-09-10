using System.Collections.Generic;
using WarehouseCompanyApp.DataAccess;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.Controllers
{
    public class ReceiptController
    {
        private ReceiptDataAccess dataAccess = new ReceiptDataAccess();

        public List<Receipt> GetAllReceipts() => dataAccess.GetAllReceipts();
        public void AddReceipt(Receipt receipt) => dataAccess.AddReceipt(receipt);
        public void UpdateReceipt(Receipt receipt) => dataAccess.UpdateReceipt(receipt);
        public void DeleteReceipt(int receiptId) => dataAccess.DeleteReceipt(receiptId);
    }
}