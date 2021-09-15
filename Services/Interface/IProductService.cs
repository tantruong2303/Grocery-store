using System.Collections.Generic;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface IProductService
    {
        public (List<Product>, int) GetProducts(double min, double max);
        public bool CreateProductHandler(CreateProductDTO input, ViewDataDictionary dataView);
        public bool UpdateProductHandler(UpdateProductDTO input, ViewDataDictionary dataView);
        public Product GetProductById(string productId);

    }
}