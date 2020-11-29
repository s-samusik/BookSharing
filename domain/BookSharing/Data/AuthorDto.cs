using System.Collections.Generic;

namespace BookSharing.Data
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublisherId { get; set; }

        public virtual PublisherDto Publisher { get; set; }
        public virtual ICollection<BookDto> Books { get; set; }
    }
}
