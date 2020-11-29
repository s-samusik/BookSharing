using System.Collections.Generic;

namespace BookSharing.Data
{
    public class UserTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
