using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class UserDto
    {
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
        public UserTypeDto UserType { get; set; }
    }
}
