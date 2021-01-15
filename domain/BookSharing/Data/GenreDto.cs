using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class GenreDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<BookDto> Books { get; set; }
    }
}
