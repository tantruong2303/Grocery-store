using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Utils.Common;
using Backend.Pipe;
using Backend.Services.Interface;

using Backend.Utils.Locale;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var categories = this.CategoryService.GetCategoryDropListRender(CategoryStatus.INACTIVE);
            this.ViewData["categories"] = new SelectList(categories);
            return View(Routers.CreateProduct.Page);
        }


        [HttpGet("update")]
        public IActionResult UpdateProduct(string productId)
        {
            var product = this.ProductService.GetProductById(productId);
            this.ViewData["product"] = product;

            var categories = this.CategoryService.GetCategoryDropListRender(CategoryStatus.INACTIVE);
            this.ViewData["categories"] = new SelectList(categories);
            return View(Routers.UpdateProduct.Page);
        }

        [HttpGet("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Product(double min, double max, string name, string categoryId, int pageIndex = 0, int pageSize = 12)
        {
            var categories = this.CategoryService.GetCategoryDropListRender(CategoryStatus.INACTIVE);
            var allCategory = new SelectListItem()
            {
                Value = "",
                Text = "All"
            };

            categories.Add(allCategory);
            this.ViewData["categories"] = new SelectList(categories);


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


            var (products, count) = this.ProductService.GetProducts(pageIndex, pageSize, min, max, name, categoryId, CategoryStatus.INACTIVE);
            this.ViewData["products"] = products;
            this.ViewData["total"] = count;
            return View(Routers.Product.Page);
        }
    }
}