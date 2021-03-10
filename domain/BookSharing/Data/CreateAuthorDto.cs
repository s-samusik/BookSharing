using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class CreateAuthorDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
