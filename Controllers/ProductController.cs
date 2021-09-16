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

            ServerResponse.SetMessage(CustomLanguageValidator.MessageKey.MESSAGE_ADD_SUCCESS, this.ViewData);
            return Redirect(Routers.Product.Link);
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

            ServerResponse.SetMessage(CustomLanguageValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, this.ViewData);
            return Redirect(Routers.Product.Link);
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Product(double min, double max, string name, string categoryId)
        {
            var (products, count) = this.ProductService.GetProducts(0, double.MaxValue, "", "");
            if (name == null) name = "";
            if (categoryId == null) categoryId = "";


            var input = new SearchProductDTO()
            {
                Min = min,
                Max = max,
                Name = name,
                CategoryId = categoryId
            };

            ValidationResult result = new SearchProductDTOValidator().Validate(input);
            if (!result.IsValid || (min > max))
            {
                ServerResponse.MapDetails(result, this.ViewData);
                this.ViewData["products"] = products;
                this.ViewData["count"] = count;
                return View(Routers.Product.Page);
            }

            if (min != 0 && max != 0 && name != "" && categoryId != "")
            {
                (products, count) = this.ProductService.GetProducts(min, max, name, categoryId);

            }
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;
            return View(Routers.Product.Page);
        }
    }
}