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

        // [HttpGet("")]
        // public IActionResult Cart()
        // {
        //     var cart = this.HttpContext.Session.GetString(CartSession);
        //     if (cart != null && cart != "")
        //     {
        //         var list = this.CartService.convertStringToCartItem(cart);
        //         var products = this.CartService.GetCartItems(list);
        //         this.ViewData["cartItems"] = products;
        //     }
        //     return View(Routers.Cart.Page);
        // }

        [HttpGet("add")]
        public IActionResult HandleAddToCart(string productId, int quantity)
        {

            Product product = this.ProductService.GetProductById(productId);
            if (product != null)
            {
                string cart = this.HttpContext.Session.GetString(CartSession);
                if (cart != null)
                {
                    var list = this.CartService.convertStringToCartItem(cart);
                    bool check = false;
                    //cart exit and check if product exist
                    foreach (var item in list)
                    {
                        if (item.Key == productId)
                        {
                            item.Value.Quantity += quantity;
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        //create new cart item
                        var newItem = new CartItem();
                        newItem.ProductId = product.ProductId;
                        newItem.Quantity = 1;

                        list.Add(productId, newItem);

                    }
                    this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
                }
                else
                {
                    //create new cart item
                    var item = new CartItem();
                    item.ProductId = product.ProductId;
                    item.Quantity = 1;
                    Dictionary<string, CartItem> list = new Dictionary<string, CartItem>();
                    list.Add(productId, item);

                    // add list to new cart session
                    this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
                }
            }
            else
            {
                return Redirect(Routers.Product.Link);
            }
            return Redirect(Routers.Home.Link);
        }

        // [HttpPost("remove")]
        // public IActionResult HandleRemoveCartItem(string productId)
        // {
        //     Product product = this.ProductService.GetProductById(productId);
        //     if (product != null)
        //     {
        //         var cart = this.HttpContext.Session.GetString(CartSession);
        //         var list = this.CartService.convertStringToCartItem(cart);
        //         var check = false;
        //         foreach (var item in list)
        //         {
        //             if (item.Key == productId)
        //             {
        //                 check = true;
        //             }
        //         }
        //         if (check)
        //         {
        //             list.Remove(productId);
        //         }
        //         this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
        //     }
        //     else
        //     {
        //         return Redirect(Routers.Product.Link);
        //     }
        //     return this.Cart();
        // }

    }
}