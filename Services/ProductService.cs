using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FluentValidation.Results;
using Backend.Utils.Common;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Backend.Utils.Interface;
using Backend.Models;
using Backend.Services.Interface;
using System;
using Backend.Utils;
using System.Collections.Generic;

namespace Backend.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IUploadFileService UploadFileService;
        private readonly DBContext DBContext;

        public ProductService(DBContext dBContext, IProductRepository productRepository, ICategoryRepository categoryRepository, IUploadFileService uploadFileService)
        {
            this.DBContext = dBContext;
            this.ProductRepository = productRepository;
            this.CategoryRepository = categoryRepository;
            this.UploadFileService = uploadFileService;
        }

        public Product GetProductById(string productId)
        {
            return this.ProductRepository.GetProductById(productId);
        }

        public (List<Product>, int) GetProducts(int pageIndex, int pageSize, double min, double max, string name, string categoryId, CategoryStatus categoryStatus)
        {
            return this.ProductRepository.GetProducts(pageIndex, pageSize, min, max, name, categoryId, categoryStatus);
        }
        public bool CreateProductHandler(Product product)
        {
            return this.ProductRepository.CreateProductHandler(product);
        }

        public bool UpdateProductHandler(Product product)
        {
            return this.ProductRepository.UpdateProductHandler(product);
        }

    }
}