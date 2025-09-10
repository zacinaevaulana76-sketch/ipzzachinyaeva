using System.Collections.Generic;
using WarehouseCompanyApp.DataAccess;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.Controllers
{
    public class ShipmentController
    {
        private ShipmentDataAccess dataAccess = new ShipmentDataAccess();

        public List<Shipment> GetAllShipments() => dataAccess.GetAllShipments();
        public void AddShipment(Shipment shipment) => dataAccess.AddShipment(shipment);
        public void UpdateShipment(Shipment shipment) => dataAccess.UpdateShipment(shipment);
        public void DeleteShipment(int shipmentId) => dataAccess.DeleteShipment(shipmentId);
    }
}