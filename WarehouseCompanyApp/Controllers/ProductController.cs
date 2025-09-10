using System.Collections.Generic;
using WarehouseCompanyApp.DataAccess;
using WarehouseCompanyApp.Models;

namespace WarehouseCompanyApp.Controllers
{
    public class ProductController
    {
        private ProductDataAccess dataAccess = new ProductDataAccess();

        public List<Product> GetAllProducts() => dataAccess.GetAllProducts();

        public void AddProduct(Product product) => dataAccess.AddProduct(product);

        public void UpdateProduct(Product product) => dataAccess.UpdateProduct(product);

        public void DeleteProduct(int productId) => dataAccess.DeleteProduct(productId);
    }
}