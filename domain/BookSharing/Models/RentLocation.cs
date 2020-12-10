using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class RentLocation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Country can't be longer than 50 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City can't be longer than 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(50, ErrorMessage = "Street can't be longer than 50 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Building is required")]
        [StringLength(10, ErrorMessage = "Building can't be longer than 10 characters")]
        public string Building { get; set; }
    }
}
