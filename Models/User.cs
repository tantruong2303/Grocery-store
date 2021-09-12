
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
        public string UserId { set; get; }

        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [Required]
        [StringLength(50)]
        public string Username { set; get; }

        [StringLength(255)]
        public string Password { set; get; }

        [Required]
        [StringLength(255)]
        public string Email { set; get; }

        [Required]
        [StringLength(50)]
        public string Phone { set; get; }

        [StringLength(50)]
        public string Address { set; get; }

        [Required]
        [StringLength(50)]
        public string CreateDate { set; get; }

        [Required]
        public UserRole Role { get; set; }
    }
}