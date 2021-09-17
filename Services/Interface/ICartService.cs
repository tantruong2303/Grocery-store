using Backend.Models;
using System.Collections.Generic;


namespace Backend.Services.Interface
{
    public interface ICartService
    {
        public string convertCartItemToString(Dictionary<string, CartItem> list);
        public Dictionary<string, CartItem> convertStringToCartItem(string input);
        public List<Product> GetCartItems(Dictionary<string, CartItem> list);

    }
}