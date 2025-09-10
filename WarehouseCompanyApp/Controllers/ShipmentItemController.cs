using System.Collections.Generic;
using WarehouseCompanyApp.DataAccess;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.Controllers
{
    public class ShipmentItemController
    {
        private ShipmentItemDataAccess dataAccess = new ShipmentItemDataAccess();

        public List<ShipmentItem> GetAllShipmentItems() => dataAccess.GetAllShipmentItems();
        public void AddShipmentItem(ShipmentItem item) => dataAccess.AddShipmentItem(item);
        public void UpdateShipmentItem(ShipmentItem item) => dataAccess.UpdateShipmentItem(item);
        public void DeleteShipmentItem(int shipmentItemId) => dataAccess.DeleteShipmentItem(shipmentItemId);
    }
}
