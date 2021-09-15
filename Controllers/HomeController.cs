using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Pipe;
using Backend.Services.Interface;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using System;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using Backend.Models;

using System.Linq;

using System.Collections;
using System.Web;


namespace Backend.Controllers
{
    [Route("")]
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
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult Index(double min, double max)
        {
            var cart = this.HttpContext.Session.GetString(CartSession);
            if (cart != null && cart != "")
            {
                var list = this.CartService.convertStringToCartItem(cart);
                var getCart = this.CartService.GetCartItems(list);
                this.ViewData["cartItems"] = getCart;
            }

            var (products, count) = this.ProductService.GetProducts(0, double.MaxValue);
            var input = new SearchProductDTO()
            {
                Min = min,
                Max = max
            };

            ValidationResult result = new SearchProductDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, this.ViewData);
                this.ViewData["products"] = products;
                this.ViewData["count"] = count;
                return View(Routers.Home.Page);
            }

            (products, count) = this.ProductService.GetProducts(min, max);
            this.ViewData["products"] = products;
            this.ViewData["count"] = count;

            return View(Routers.Home.Page);
        }
    }
}
