
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Services.Interface;
using Backend.Utils.Common;
using System.Collections.Generic;
using Backend.Models;
using Backend.Pipe;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using Backend.Utils.Locale;

namespace Backend.Controllers
{
    [Route("/api/cart")]
    [ServiceFilter(typeof(AuthGuard))]
    public class CartApiController : Controller
    {
        private readonly ICartService CartService;
        private readonly IProductService ProductService;
        private const string CartSession = "CartSession";
        public CartApiController(ICartService cartService, IProductService productService)
        {
            this.CartService = cartService;
            this.ProductService = productService;
        }



        [HttpPost("add")]
        public IActionResult HandleAddToCart([FromBody] AddToCartDto body)
        {

            var res = new ServerApiResponse<object>();

            ValidationResult result = new AddToCartDtoValidator().Validate(body);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }


            string cart = this.HttpContext.Session.GetString(CartSession);
            Dictionary<string, CartItem> list = this.CartService.convertStringToCartItem(cart); ;
            if (list == null)
            {
                list = new Dictionary<string, CartItem>();
            }

            Product product = this.ProductService.GetProductById(body.productId);
            if (product.Quantity <= 0)
            {
                Dictionary<string, object> context = new Dictionary<string, object>();
                context.Add("Name", product.Name);
                res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_OUT_OF_STOCK, context);
                return new BadRequestObjectResult(res.getResponse());
            }

            foreach (var item in list)
            {
                if (item.Key == body.productId)
                {

                    if (product.Quantity < item.Value.Quantity + body.quantity)
                    {
                        item.Value.Quantity = product.Quantity;
                        this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
                        Dictionary<string, object> context = new Dictionary<string, object>();
                        context.Add("Name", product.Name);
                        context.Add("Quantity", product.Quantity);
                        res.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_OUT_OF_STOCK, context);
                        return new BadRequestObjectResult(res.getResponse());
                    }
                    else
                    {
                        item.Value.Quantity += body.quantity;
                        if (item.Value.Quantity <= 0)
                        {
                            list.Remove(body.productId);
                        }
                    }
                    this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
                    res.data = this.CartService.GetCartItems(list);
                    res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_ADD_CART_SUCCESS);
                    return new ObjectResult(res.getResponse());
                }
            }

            var cartItem = new CartItem();
            cartItem.ProductId = product.ProductId;
            cartItem.Quantity = 1;
            list.Add(body.productId, cartItem);
            this.HttpContext.Session.SetString(CartSession, this.CartService.convertCartItemToString(list));
            res.data = this.CartService.GetCartItems(list);
            res.setMessage(CustomLanguageValidator.MessageKey.MESSAGE_ADD_CART_SUCCESS);
            return new ObjectResult(res.getResponse());
        }
        [HttpGet("")]
        public IActionResult handleOnGetCart()
        {
            var res = new ServerApiResponse<object>();
            var cart = this.HttpContext.Session.GetString(CartSession) ?? "";

            var list = this.CartService.convertStringToCartItem(cart);

            var getCart = this.CartService.GetCartItems(list);

            res.data = getCart;
            return new ObjectResult(res.getResponse());
        }
    }
}