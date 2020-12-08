using System.Collections.Generic;

namespace BookSharing.Data
{
    public class RentLocationDto
    {
        [Newtonsoft.Json.JsonConstructor]
        public RentLocationDto()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }

        public virtual ICollection<BookDto> Books { get; set; }
    }
}
