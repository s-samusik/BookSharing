using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
