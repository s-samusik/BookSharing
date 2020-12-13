namespace BookSharing.Data
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public AuthorDto Author { get; set; }
        public GenreDto Genre { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}
