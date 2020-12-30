using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title can't be longer than 50 characters")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public virtual Author Author { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public virtual Genre Genre { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public virtual Publisher Publisher { get; set; }
    }
}
