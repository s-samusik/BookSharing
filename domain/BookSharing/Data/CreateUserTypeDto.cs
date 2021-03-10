using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class CreateUserTypeDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User's type not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
