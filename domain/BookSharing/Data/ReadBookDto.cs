namespace BookSharing.Data
{
    public class ReadBookDto
    {
        public int Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ReadGenreDto Genre { get; set; }
        public ReadAuthorDto Author { get; set; }
        public ReadPublisherDto Publisher { get; set; }
    }
}
