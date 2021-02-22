using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public byte[] Cover { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }
        
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        
        public virtual Genre Genre { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
