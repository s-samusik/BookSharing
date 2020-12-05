using System.Collections.Generic;

namespace BookSharing.Data
{
    public class RentLocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RentLocationAddressId { get; set; }

        public virtual RentLocationAddressDto RentLocationAddress { get; set; }
        public virtual ICollection<BookDto> Books { get; set; }
    }
}
