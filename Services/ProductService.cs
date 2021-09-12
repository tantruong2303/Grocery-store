using backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FluentValidation.Results;
using backend.Utils.Common;
using backend.DAO.Interface;
using backend.Utils.Locale;
using backend.Models;
using backend.Services.Interface;
using System;
using backend.Utils;

namespace backend.Services
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

            var isExistCategory = this.categoryRepository.getCategoryByCategoryId(input.categoryId);
            if (isExistCategory == null)
            {
                ServerResponse.setFieldErrorMessage("categoryId", CustomLanguageValidator.ErrorMessageKey.ERROR_NOT_FOUND, dataView);
                return false;
            }

            var isExistProduct = this.productRepository.getProductByProductName(input.name);
            if (isExistProduct != null)
            {
                ServerResponse.setFieldErrorMessage("name", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }

            var product = new Product();
            product.productId = Guid.NewGuid().ToString();
            product.name = input.name;
            product.description = input.description;
            product.status = (ProductStatus)1;
            product.retailPrice = input.retailPrice;
            product.originalPrice = input.originalPrice;
            product.createDate = DateTime.Now.ToShortDateString();
            product.quantity = input.quantity;
            product.imageUrl = "";
            product.categoryId = input.categoryId;
            this.dBContext.product.Add(product);
            this.dBContext.SaveChanges();
            return true;
        }
    }
}