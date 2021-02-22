using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class UserCreateDto
    {
        public IFormFile Avatar { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nickname not specified")]
        [StringLength(50, MinimumLength = 5)]
        public string Nickname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password not specified")]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string PasswordConfirm { get; set; }
    }
}
