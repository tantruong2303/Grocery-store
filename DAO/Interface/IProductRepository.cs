using Backend.Models;
using System.Collections.Generic;

namespace Backend.DAO.Interface
{
    public interface IProductRepository
    {
        public Product GetProductById(string id);
        public Product GetProductByProductName(string name);
        public (List<Product>, int) GetProducts();
    }
}