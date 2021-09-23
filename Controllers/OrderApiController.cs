using System;
using Microsoft.AspNetCore.Mvc;
using Backend.Utils.Common;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Backend.Pipe;
using Backend.Models;
using Backend.Utils.Locale;
using Backend.Controllers.DTO;


using System.Collections.Generic;

using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Utils;
using Backend.DAO.Interface;

namespace Backend.Controllers
{
    public class OrderApiController : Controller
    {
        private readonly IOrderService OrderService;
        private const string CartSession = "CartSession";
        private readonly ICartService CartService;
        private readonly IProductService ProductService;
        public OrderApiController(IOrderService orderService, ICartService cartService, IProductService productService)
        {
            this.OrderService = orderService;
            this.CartService = cartService;
            this.ProductService = productService;
        }
        [HttpPost("")]
        [ServiceFilter(typeof(AuthGuard))]
        public IActionResult CreateOrder(PaymentMethod paymentMethod)
        {
            string cart = this.HttpContext.Session.GetString(CartSession);
            if (cart == null || cart == "")
            {

                return Redirect(Routers.Home.Link + $"?errorMessage=cart is empty");
            }

            var input = new CreateOrderDTO()
            {
                PaymentMethod = paymentMethod,
            };

            ValidationResult result = new CreateOrderDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, this.ViewData);
                return Redirect(Routers.Home.Link);
            }


            var list = this.CartService.convertStringToCartItem(cart);
            foreach (var cartItem in list)
            {
                Product product = this.ProductService.GetProductById(cartItem.Key);
                if (cartItem.Value.Quantity > product.Quantity)
                {
                    return Redirect(Routers.Home.Link + $"?errorMessage={product.Name} have only {product.Quantity}");
                }
            }

            this.OrderService.CreateOrderHandler(input, this.ViewData, list);
            this.HttpContext.Session.Remove(CartSession);

            return Redirect(Routers.Home.Link + "?message=create order success");
        }
    }
}