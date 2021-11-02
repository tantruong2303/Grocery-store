using System.Collections.Generic;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface IProductService
    {
        public (List<Product>, int) GetProducts(int pageIndex, int pageSize, double min, double max, string name, string categoryId, CategoryStatus categoryStatus);
        public bool CreateProductHandler(Product product);
        public bool UpdateProductHandler(Product product);
        public Product GetProductById(string productId);

    }
}