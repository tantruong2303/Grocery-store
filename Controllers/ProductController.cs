
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Utils.Common;
using backend.Controllers.DTO;
using backend.Pipe;
using backend.Services.Interface;

namespace backend.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("create")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult CreateProduct()
        {
            return View(Routers.CreateProduct.page);
        }

        [HttpPost("create")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult handleCreateProduct(string name, string description, float originalPrice, float retailPrice, int quantity, string categoryId)
        {
            var input = new CreateProductDTO()
            {
                name = name,
                description = description,
                retailPrice = retailPrice,
                originalPrice = originalPrice,
                quantity = quantity,
                categoryId = categoryId,
            };

            var isValid = this.productService.createProductHandler(input, this.ViewData);

            if (!isValid)
            {
                return View(Routers.CreateProduct.page);
            }

            return Redirect(Routers.Product.link);
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Product()
        {
            return View(Routers.Product.page);
        }

    }
}