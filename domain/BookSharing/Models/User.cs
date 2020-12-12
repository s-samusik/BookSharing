using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nickname is required")]
        [StringLength(50, ErrorMessage = "Nickname can't be longer than 50 characters")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email can't be longer than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [StringLength(20, ErrorMessage = "PhoneNumber can't be longer than 20 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password can't be longer than 50 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "UserType is required")]
        public virtual UserType UserType { get; set; }
    }
}
