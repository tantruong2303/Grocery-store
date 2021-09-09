using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{

    [Table("tblOrderItem")]
    public class OrderItem
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string orderItemId { set; get; }

        [Required]
        public int quantity { set; get; }

        [Required]
        public float salePrive { set; get; }

        [Required]
        [StringLength(50)]
        public string createDate { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("tblOrder")]
        public string orderId { set; get; }
        public virtual Order order { set; get; }


        [Required]
        [StringLength(50)]
        [ForeignKey("tblProduct")]
        public string productId { set; get; }

        public virtual Product product { set; get; }
    }
}