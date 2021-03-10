using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class CreateBookDto
    {
        public IFormFile Cover { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Genre not specified")]
        public CreateGenreDto Genre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Author not specified")]
        public CreateAuthorDto Author { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Publisher not specified")]
        public CreatePublisherDto Publisher { get; set; }
    }
}
