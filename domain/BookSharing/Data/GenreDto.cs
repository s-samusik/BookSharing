using System.Collections.Generic;

namespace BookSharing.Data
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookDto> Books { get; set; }
    }
}