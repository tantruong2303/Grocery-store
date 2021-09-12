using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{



    public enum OrderStatus
    {
        ACTIVE = 1,
        INACTIVE = 0
    }


    [Table("tblOrder")]
    public class Order
    {


        [Required]
        [StringLength(50)]
        [Key]
        public string orderId { set; get; }

        [Required]
        public OrderStatus status { get; set; }

        [Required]
        public float total { get; set; }

        [Required]
        [StringLength(50)]
        public string createDate { set; get; }

        [Required]
        [StringLength(50)]
        public string paymentMethod { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("tblUser")]
        public string customerId { set; get; }

        public virtual User customer { set; get; }
    }
}