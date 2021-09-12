using System.Linq;
using System;

using Backend.DAO.Interface;

using Backend.Utils;
using Backend.Models;

namespace Backend.DAO
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBContext DBContext;
        public ProductRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public Product GetProductById(string id)
        {
            Product product = this.DBContext.product.FirstOrDefault(item => item.productId == id);
            return product;
        }

        public Product GetProductByProductName(string name)
        {
            Product product = this.DBContext.product.FirstOrDefault(item => item.name == name);
            return product;
        }

    }
}