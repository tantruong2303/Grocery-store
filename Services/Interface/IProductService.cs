using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface IProductService
    {
        public bool CreateProductHandler(CreateProductDTO input, ViewDataDictionary dataView);
        public bool UpdateProductHandler(UpdateProductDTO input, ViewDataDictionary dataView);
        public List<Category> GetCategories();
        public Product GetProduct(string productId);

    }
}