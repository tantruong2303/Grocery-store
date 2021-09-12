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
        public string OrderId { set; get; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public float Total { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateDate { set; get; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { set; get; }

        [Required]
        [StringLength(50)]
        [ForeignKey("tblUser")]
        public string CustomerId { set; get; }

        public virtual User Customer { set; get; }
    }
}