using System.Linq;
using Backend.DAO.Interface;
using System.Collections.Generic;
using Backend.Utils;
using Backend.Models;
using System;

namespace Backend.DAO
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBContext DBContext;
        public ProductRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public Product GetProductById(string productId)
        {
            Product product = this.DBContext.Product.FirstOrDefault(item => item.ProductId == productId);
            return product;
        }

        public Product GetProductByProductName(string name)
        {
            Product product = this.DBContext.Product.FirstOrDefault(item => item.Name == name);
            return product;
        }

        public (List<Product>, int) GetProducts()
        {
            List<Product> products = this.DBContext.Category.Join(
                DBContext.Product, category => category.CategoryId,
                product => product.CategoryId,
                (category, product) => new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Status = product.Status,
                    OriginalPrice = product.OriginalPrice,
                    RetailPrice = product.RetailPrice,
                    CreateDate = product.CreateDate,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl,
                    CategoryId = product.CategoryId,
                    Category = category
                }).ToList();

            return (products, products.Count);
        }

    }
}