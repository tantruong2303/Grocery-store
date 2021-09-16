using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Pipe;
using Backend.Services.Interface;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;

namespace Backend.Controllers
{
    [Route("")]
    [ServiceFilter(typeof(AuthGuard))]
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";
        private readonly IProductService ProductService;
        private readonly ICartService CartService;
        public HomeController(IProductService productService, ICartService cartService)
        {
            this.ProductService = productService;
            this.CartService = cartService;
        }

        [HttpGet("")]
        public IActionResult Index(double min, double max, string name, string categoryId)
        {
            var cart = this.HttpContext.Session.GetString(CartSession);
            if (cart != null && cart != "")
            {
                var list = this.CartService.convertStringToCartItem(cart);
                var getCart = this.CartService.GetCartItems(list);
                this.ViewData["cartItems"] = getCart;
            }

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
                return View(Routers.Home.Page);
            }

            if (min != 0 && max != 0 && name != "" && categoryId != "")
            {
                (products, count) = this.ProductService.GetProducts(min, max, name, categoryId);

            }
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;

            return View(Routers.Home.Page);
        }
    }
}
