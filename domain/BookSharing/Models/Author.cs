using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Nickname { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
