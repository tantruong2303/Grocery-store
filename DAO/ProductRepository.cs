using System.Linq;
using System;

using backend.DAO.Interface;

using backend.Utils;
using backend.Models;

namespace backend.DAO
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBContext dbContext;
        public ProductRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product getProductById(string id)
        {
            Product product = this.dbContext.product.FirstOrDefault(item => item.productId == id);
            return product;
        }

        public Product getProductByProductName(string name)
        {
            Product product = this.dbContext.product.FirstOrDefault(item => item.name == name);
            return product;
        }

    }
}