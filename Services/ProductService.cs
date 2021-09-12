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

        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly DBContext dBContext;

        public ProductService(DBContext dBContext, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.dBContext = dBContext;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }
        public bool createProductHandler(CreateProductDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new CreateProductDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }

            var isExistCategory = this.categoryRepository.GetCategoryByCategoryId(input.CategoryId);
            if (isExistCategory == null)
            {
                ServerResponse.setFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }

            var isExistProduct = this.productRepository.GetProductByProductName(input.Name);
            if (isExistProduct != null)
            {
                ServerResponse.setFieldErrorMessage("name", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }

            var product = new Product();
            product.productId = Guid.NewGuid().ToString();
            product.name = input.Name;
            product.description = input.Description;
            product.status = (ProductStatus)1;
            product.retailPrice = input.RetailPrice;
            product.originalPrice = input.OriginalPrice;
            product.createDate = DateTime.Now.ToShortDateString();
            product.quantity = input.Quantity;
            product.imageUrl = "";
            product.categoryId = input.CategoryId;
            this.dBContext.product.Add(product);
            this.dBContext.SaveChanges();
            return true;
        }
    }
}