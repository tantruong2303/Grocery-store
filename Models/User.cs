
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{

    public enum UserRole
    {
        MANGER = 1,
        CUSTOMER = 0
    }

    [Table("tblUser")]
    public class User
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string userId { set; get; }

        [Required]
        [StringLength(50)]
        public string name { set; get; }

        [Required]
        [StringLength(50)]
        public string username { set; get; }

        [StringLength(255)]
        public string password { set; get; }

        [Required]
        [StringLength(255)]
        public string email { set; get; }

        [Required]
        [StringLength(50)]
        public string phone { set; get; }

        [StringLength(50)]
        public string address { set; get; }

        [Required]
        [StringLength(50)]
        public string createDate { set; get; }

        [Required]
        public UserRole role { get; set; }
    }
}