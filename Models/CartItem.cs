using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class CartItem
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public override string ToString()
        {
            return "CartItem: \nProductId: " + ProductId + " \nQuantity: " + Quantity;
        }
    }
}