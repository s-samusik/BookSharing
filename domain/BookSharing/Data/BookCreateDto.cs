using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class BookCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public GenreCreateDto Genre { get; set; }
        
        [Required]
        public AuthorCreateDto Author { get; set; }
        
        [Required]
        public PublisherCreateDto Publisher { get; set; }
    }
}
