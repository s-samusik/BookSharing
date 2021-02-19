﻿using System.ComponentModel.DataAnnotations;

namespace BookSharing.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Nickname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        public int UserTypeId { get; set; } 

        public virtual UserType UserType { get; set; }
    }
}
