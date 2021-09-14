using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Utils.Common;
using Backend.Controllers.DTO;
using Backend.Pipe;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var categories = this.ProductService.GetCategories();

            this.ViewData["categories"] = new SelectList(categories, "CategoryId", "Name", categories[0].CategoryId);
            return View(Routers.CreateProduct.Page);
        }

        [HttpPost("create")]
        public IActionResult HandleCreateProduct(string name, string description, float originalPrice, float retailPrice, int quantity, IFormFile file, string categoryId)
        {
            var input = new CreateProductDTO()
            {
                Name = name,
                Description = description,
                RetailPrice = retailPrice,
                OriginalPrice = originalPrice,
                Quantity = quantity,
                File = file,
                CategoryId = categoryId,
            };

            var isValid = this.ProductService.CreateProductHandler(input, this.ViewData);

            if (!isValid)
            {
                this.ViewData["categories"] = this.ProductService.GetCategories();
                return this.CreateProduct();
            }


            return Redirect(Routers.Product.Link);
        }

        [HttpGet("update")]
        public IActionResult UpdateProduct(string productId)
        {
            var product = this.ProductService.GetProduct(productId);
            this.ViewData["product"] = product;

            var categories = this.ProductService.GetCategories();
            this.ViewData["categories"] = new SelectList(categories, "CategoryId", "Name", product.CategoryId);

            return View(Routers.UpdateProduct.Page);
        }

        [HttpPost("update")]
        public IActionResult HandleUpdateProduct(string productId, string name, ProductStatus status, string description, float originalPrice, float retailPrice, int quantity, IFormFile file, string categoryId)
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
                File = file,
                CategoryId = categoryId,
            };
            var isValid = this.ProductService.UpdateProductHandler(input, this.ViewData);
            if (!isValid)
            {

                return this.UpdateProduct(productId);
            }

            return Redirect(Routers.Product.Link);
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Product()
        {
            var (products, count) = this.ProductService.GetProducts();
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;
            return View(Routers.Product.Page);
        }

    }
}