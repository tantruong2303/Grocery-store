using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FluentValidation.Results;
using Backend.Utils.Common;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Backend.Models;
using Backend.Services.Interface;
using System;
using Backend.Utils;

namespace Backend.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly DBContext DBContext;

        public ProductService(DBContext dBContext, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.DBContext = dBContext;
            this.ProductRepository = productRepository;
            this.CategoryRepository = categoryRepository;
        }
        public bool CreateProductHandler(CreateProductDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new CreateProductDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return false;
            }

            var isExistCategory = this.CategoryRepository.GetCategoryByCategoryId(input.CategoryId);
            if (isExistCategory == null)
            {
                ServerResponse.SetFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }

            var isExistProduct = this.ProductRepository.GetProductByProductName(input.Name);
            if (isExistProduct != null)
            {
                ServerResponse.SetFieldErrorMessage("name", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }

            var product = new Product();
            product.ProductId = Guid.NewGuid().ToString();
            product.Name = input.Name;
            product.Description = input.Description;
            product.Status = (ProductStatus)1;
            product.RetailPrice = input.RetailPrice;
            product.OriginalPrice = input.OriginalPrice;
            product.CreateDate = DateTime.Now.ToShortDateString();
            product.Quantity = input.Quantity;
            product.ImageUrl = "";
            product.CategoryId = input.CategoryId;
            this.DBContext.Product.Add(product);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}