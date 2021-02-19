using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class GenreCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Genre not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
