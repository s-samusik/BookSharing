namespace BookSharing.Data
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual AuthorDto Author { get; set; }
        public virtual GenreDto Genre { get; set; }
        public virtual PublisherDto Publisher { get; set; }
        public virtual RentLocationDto RentLocation { get; set; }
    }
}
