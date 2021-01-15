using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}
