using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class RentLocationDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Country { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Building { get; set; }
    }
}
