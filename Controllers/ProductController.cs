
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend.Models;
using Backend.Utils.Common;
using Backend.Controllers.DTO;
using Backend.Pipe;
using Backend.Services.Interface;

namespace Backend.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;

        public ProductController(IProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet("create")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult CreateProduct()
        {
            this.ViewData["categories"] = this.ProductService.GetCategories();
            return View(Routers.CreateProduct.Page);
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(AuthGuard))]
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

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Product()
        {

            return View(Routers.Product.Page);
        }

    }
}