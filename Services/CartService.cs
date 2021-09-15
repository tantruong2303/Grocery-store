using System.Collections.Generic;
using Backend.Services.Interface;
using System;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using Backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Utils;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Backend.Models;
using Backend.Utils.Interface;
using System.Linq;

namespace Backend.Services
{
    public class CartService : ICartService
    {
        private readonly IProductService ProductService;

        public CartService(IProductService productService)
        {
            this.ProductService = productService;
        }
        public Dictionary<string, CartItem> convertStringToCartItem(string input)
        {

            Dictionary<string, CartItem> list = new Dictionary<string, CartItem>();
            if (input != null && input.Trim().Length != 0)
            {
                var arr = input.Split(",");
                foreach (var item in arr)
                {
                    var arr2 = item.Split(";");
                    var cartItem = new CartItem();
                    cartItem.ProductId = arr2[0];
                    cartItem.Quantity = Int32.Parse(arr2[1]);
                    list.Add(cartItem.ProductId, cartItem);
                }
            }
            return list;
        }

        public string convertCartItemToString(Dictionary<string, CartItem> list)
        {
            string cartSession = "";
            foreach (var item in list)
            {
                string[] arr = { item.Key, item.Value.Quantity.ToString() };
                var readablePhrase = string.Join(";", arr);
                if (cartSession == "")
                {
                    cartSession = readablePhrase;
                }
                else
                {
                    cartSession += "," + readablePhrase;
                }

            }
            return cartSession;
        }

        public List<Product> GetCartItems(Dictionary<string, CartItem> list)
        {
            List<Product> products = new List<Product>();
            foreach (var item in list)
            {
                Product product = this.ProductService.GetProductById(item.Value.ProductId);
                product.Quantity = item.Value.Quantity;
                products.Add(product);
            }
            return products;
        }

        // public bool RemoveCartItem(string productId)
        // {
        //     var res = false;

        // }
    }
}