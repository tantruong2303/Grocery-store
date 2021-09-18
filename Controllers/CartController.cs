using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Services.Interface;
using Backend.Utils.Common;
using System.Collections.Generic;
using Backend.Models;
using Backend.Pipe;
using Backend.Utils.Locale;

namespace Backend.Controllers
{
    [Route("cart")]
    [ServiceFilter(typeof(AuthGuard))]
    public class CartController : Controller
    {
        private readonly ICartService CartService;
        private readonly IProductService ProductService;
        private const string CartSession = "CartSession";
        public CartController(ICartService cartService, IProductService productService)
        {
            this.CartService = cartService;
            this.ProductService = productService;
        }



        [HttpGet("add")]
        public IActionResult HandleAddToCart(string productId, int quantity)
        {

            string cart = this.HttpContext.Session.GetString(CartSession);
            Dictionary<string, CartItem> list = this.CartService.convertStringToCartItem(cart); ;
            if (list == null)
            {
                list = new Dictionary<string, CartItem>();
            }

            Product product = this.ProductService.GetProductById(productId);
            if (product.Quantity <= 0)
            {
                return Redirect(Routers.Home.Link + $"?errorMessage=Sorry, {product.Name} is out of stock ");
            }

            foreach (var item in list)
            {
                if (item.Key == productId)
                {

                    if (product.Quantity < item.Value.Quantity + quantity)
                    {
                        item.Value.Quantity = product.Quantity;
                        this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
                        return Redirect(Routers.Home.Link + $"?errorMessage=Sorry, {product.Name} only have {product.Quantity} ");
                    }
                    else
                    {
                        item.Value.Quantity += quantity;
                        if (item.Value.Quantity <= 0)
                        {
                            list.Remove(productId);
                        }
                    }
                    this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
                    return Redirect(Routers.Home.Link + "?message=add cart success");
                }
            }

            var cartItem = new CartItem();
            cartItem.ProductId = product.ProductId;
            cartItem.Quantity = 1;
            list.Add(productId, cartItem);

            this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
            return Redirect(Routers.Home.Link + "?message=add cart success");
        }
    }
}