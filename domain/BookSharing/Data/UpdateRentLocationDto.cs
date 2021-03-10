using System.ComponentModel.DataAnnotations;

namespace BookSharing.Data
{
    public class UpdateRentLocationDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Country not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Street not specified")]
        [StringLength(50, MinimumLength = 3)]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Building not specified")]
        [StringLength(50, MinimumLength = 1)]
        public string Building { get; set; }
    }
}
