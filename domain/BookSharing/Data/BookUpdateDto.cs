using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class BookUpdateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Genre Id not specified")]
        public int GenreId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Author Id not specified")]
        public int AuthorId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Publisher Id not specified")]
        public int PublisherId { get; set; }
    }
}
