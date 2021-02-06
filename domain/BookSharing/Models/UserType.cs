using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
    }
}
