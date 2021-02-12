namespace BookSharing.Data
{
    public class BookReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GenreReadDto Genre { get; set; }
        public AuthorReadDto Author { get; set; }
        public PublisherReadDto Publisher { get; set; }
    }
}
