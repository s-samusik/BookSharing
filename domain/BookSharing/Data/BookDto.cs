using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public AuthorDto Author { get; set; }
       
        [Required]
        public GenreDto Genre { get; set; }
        
        [Required]
        public PublisherDto Publisher { get; set; }
    }
}
