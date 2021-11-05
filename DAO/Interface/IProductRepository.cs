using Backend.Models;
using System.Collections.Generic;

namespace Backend.DAO.Interface
{
    public interface IProductRepository
    {
        public Product GetProductById(string productId);
        public Product GetProductByProductName(string name);
        public (List<Product>, int) GetProducts(int pageIndex, int pageSize, double min, double max, string name, string categoryId, CategoryStatus categoryStatus);
        public bool CreateProductHandler(Product product);
        public bool UpdateProductHandler(Product product);
    }
}