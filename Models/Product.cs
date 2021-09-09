using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backend.Models
{
    public enum ProductStatus
    {
        ACTIVE = 1,
        INACTIVE = 0
    }

    [Table("tblProduct")]
    public class Product
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string productId { set; get; }

        [Required]
        [StringLength(50)]
        public string name { set; get; }

        [Required]
        [StringLength(500)]
        public string description { set; get; }

        [Required]
        public ProductStatus status { get; set; }

        [Required]
        public float originalPrice { get; set; }

        [Required]
        public float retailPrice { get; set; }


        [Required]
        [StringLength(50)]
        public string createDate { set; get; }

        [Required]
        public int quantity { get; set; }

        [Required]
        [StringLength(255)]
        public string imageUrl { set; get; }


        [Required]
        [StringLength(50)]
        [ForeignKey("tblCategory")]
        public string categoryId { set; get; }


        public virtual Category category { set; get; }
    }
}