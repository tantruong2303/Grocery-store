using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Utils.Common;
using Backend.Controllers.DTO;
using Backend.Pipe;
using Backend.Services.Interface;
using System;
namespace Backend.Controllers
{
    [Route("product")]
    [ServiceFilter(typeof(AuthGuard))]
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;

        public ProductController(IProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet("create")]
        public IActionResult CreateProduct()
        {
            this.ViewData["categories"] = this.ProductService.GetCategories();
            return View(Routers.CreateProduct.Page);
        }

        [HttpPost("create")]
        public IActionResult HandleCreateProduct(string name, string description, float originalPrice, float retailPrice, int quantity, string categoryId)
        {
            var input = new CreateProductDTO()
            {
                Name = name,
                Description = description,
                RetailPrice = retailPrice,
                OriginalPrice = originalPrice,
                Quantity = quantity,
                CategoryId = categoryId,
            };

            var isValid = this.ProductService.CreateProductHandler(input, this.ViewData);

            if (!isValid)
            {
                this.ViewData["categories"] = this.ProductService.GetCategories();
                return View(Routers.CreateProduct.Page);
            }


            return Redirect(Routers.Product.Link);
        }

        [HttpGet("update")]
        public IActionResult UpdateProduct(string productId)
        {
            var product = this.ProductService.GetProduct(productId);
            this.ViewData["product"] = product;
            return View(Routers.UpdateProduct.Page);
        }

        [HttpPost("update")]
        public IActionResult HandleUpdateProduct(string productId, string name, ProductStatus status, string description, float originalPrice, float retailPrice, int quantity, string categoryId)
        {
            var input = new UpdateProductDTO()
            {
                ProductId = productId,
                Name = name,
                Status = status,
                Description = description,
                RetailPrice = retailPrice,
                OriginalPrice = originalPrice,
                Quantity = quantity,
                CategoryId = categoryId,
            };
            var isValid = this.ProductService.UpdateProductHandler(input, this.ViewData);
            if (!isValid)
            {
                var product = this.ProductService.GetProduct(productId);
                this.ViewData["product"] = product;
                return View(Routers.UpdateProduct.Page);
            }

            return Redirect(Routers.Product.Link);
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Product()
        {

            return View(Routers.Product.Page);
        }

    }
}