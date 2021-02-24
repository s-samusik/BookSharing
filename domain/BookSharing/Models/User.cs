using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public byte[] Avatar { get; set; }

        public string Nickname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
        
        public byte[] StoredSalt { get; set; }

        public int UserTypeId { get; set; } 

        public virtual UserType UserType { get; set; }
    }
}
