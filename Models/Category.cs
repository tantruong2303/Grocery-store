using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{

    public enum CategoryStatus
    {
        ACTIVE = 1,
        INACTIVE = 0
    }

    [Table("tblCategory")]
    public class Category
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string categoryId { set; get; }

        [Required]
        [StringLength(50)]
        public string name { set; get; }

        [Required]
        [StringLength(500)]
        public string description { set; get; }

        [Required]
        public CategoryStatus status { get; set; }

        [Required]
        [StringLength(50)]
        public string createDate { set; get; }
    }
}