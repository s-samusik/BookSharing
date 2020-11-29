namespace BookSharing.Data
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }

        public virtual AuthorDto Author { get; set; }
        public virtual GenreDto Genre { get; set; }
        public virtual PublisherDto Publisher { get; set; }
    }
}
