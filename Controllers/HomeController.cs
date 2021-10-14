using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Pipe;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Backend.Utils.Locale;


namespace Backend.Controllers
{
    [Route("")]
    [ServiceFilter(typeof(AuthGuard))]
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";
        private readonly IProductService ProductService;
        private readonly ICartService CartService;
        private readonly ICategoryService CategoryService;
        public HomeController(IProductService productService, ICartService cartService, ICategoryService categoryService)
        {
            this.ProductService = productService;
            this.CartService = cartService;
            this.CategoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult Index(double min, double max, string name, string categoryId, string message, string errorMessage, int pageIndex = 0, int pageSize = 12)
        {

            var categories = this.CategoryService.GetCategoryDropListRender();
            var allCategory = new SelectListItem()
            {
                Value = "",
                Text = "All"
            };

            categories.Add(allCategory);
            this.ViewData["categories"] = new SelectList(categories);
            var cart = this.HttpContext.Session.GetString(CartSession) ?? "";

            var list = this.CartService.convertStringToCartItem(cart);

            var getCart = this.CartService.GetCartItems(list);
            this.ViewData["cartItems"] = getCart;


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
                var query = $"?min={min}&max={max}&name={name}&CategoryId={categoryId}&message={message}&errorMessage={errorMessage}";
                return Redirect(Routers.Home.Link + query);
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


            var (products, count) = this.ProductService.GetProducts(pageIndex, pageSize, min, max, name, categoryId);
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;

            return View(Routers.Home.Page);
        }
    }
}
