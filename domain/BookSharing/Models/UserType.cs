using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
