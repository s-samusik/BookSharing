using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nickname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 7)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        public virtual UserType UserType { get; set; }
    }
}
