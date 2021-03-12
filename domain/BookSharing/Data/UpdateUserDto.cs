using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class UpdateUserDto
    {
        public IFormFile Avatar { get; set; }

        public string Nickname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User type Id not specified")]
        public int UserTypeId { get; set; }
    }
}
