using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class UserTypeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
