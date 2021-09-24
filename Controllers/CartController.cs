using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Services.Interface;
using Backend.Utils.Common;
using System.Collections.Generic;
using Backend.Models;
using Backend.Pipe;

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


            var res = new ServerApiResponse<string>();
            string cart = this.HttpContext.Session.GetString(CartSession);
            Dictionary<string, CartItem> list = this.CartService.convertStringToCartItem(cart); ;
            if (list == null)
            {
                list = new Dictionary<string, CartItem>();
            }

            Product product = this.ProductService.GetProductById(productId);
            if (product.Quantity <= 0)
            {
                res.setErrorMessage("");
                return new BadRequestObjectResult(res.getResponse());
            }

            foreach (var item in list)
            {
                if (item.Key == productId)
                {

                    if (product.Quantity < item.Value.Quantity + quantity)
                    {
                        item.Value.Quantity = product.Quantity;
                        this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
                        res.setErrorMessage("");
                        return new BadRequestObjectResult(res.getResponse());
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
                    res.setMessage("");
                    return new ObjectResult(res.getResponse());
                }
            }

            var cartItem = new CartItem();
            cartItem.ProductId = product.ProductId;
            cartItem.Quantity = 1;
            list.Add(productId, cartItem);

            this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
            res.setMessage("");
            return new ObjectResult(res.getResponse());
        }
    }
}