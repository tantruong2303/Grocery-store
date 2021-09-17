using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Utils.Common;
using Backend.Controllers.DTO;
using Backend.Pipe;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using FluentValidation.Results;
using Backend.Utils.Locale;

namespace Backend.Controllers
{
    [Route("product")]
    [RoleGuardAttribute(new UserRole[] { UserRole.MANGER })]
    [ServiceFilter(typeof(AuthGuard))]
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        private readonly ICategoryService CategoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.ProductService = productService;
            this.CategoryService = categoryService;
        }

        [HttpGet("create")]
        public IActionResult CreateProduct()
        {
            var categories = this.CategoryService.GetCategories();

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
                this.ViewData["categories"] = this.CategoryService.GetCategories();
                return this.CreateProduct();
            }

            return Redirect(Routers.Product.Link + "?message=create product success");
        }

        [HttpGet("update")]
        public IActionResult UpdateProduct(string productId)
        {
            var product = this.ProductService.GetProductById(productId);
            this.ViewData["product"] = product;

            var categories = this.CategoryService.GetCategories();
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

            return Redirect(Routers.Product.Link + "?message=update product success");
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Product(double min, double max, string name, string categoryId)
        {
            var categories = this.CategoryService.GetCategories();
            var allCategory = new Category()
            {
                CategoryId = "",
                Name = "All"
            };
            categories.Add(allCategory);
            this.ViewData["categories"] = new SelectList(categories, "CategoryId", "Name", categories[categories.Count - 1].CategoryId);


            if (name == null) name = "";
            if (categoryId == null) categoryId = "";
            if (max < 0)
            {
                ServerResponse.SetFieldErrorMessage("max", CustomLanguageValidator.ErrorMessageKey.ERROR_GREATER_ZERO, this.ViewData);
                max = 9999999;
            }
            if (max == 0)
            {
                max = 9999999;
                var query = $"?min={min}&max={max}&name={name}&CategoryId={categoryId}";
                return Redirect(Routers.Product.Link + query);
            }

            if (min < 0)
            {
                ServerResponse.SetFieldErrorMessage("min", CustomLanguageValidator.ErrorMessageKey.ERROR_GREATER_ZERO, this.ViewData);
                min = 0;
            }

            if (min > max)
            {
                ServerResponse.SetErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_MIN_GREATER_MAX, this.ViewData);
            }


            var (products, count) = this.ProductService.GetProducts(min, max, name, categoryId);
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;
            return View(Routers.Product.Page);
        }
    }
}