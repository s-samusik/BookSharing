﻿using System.ComponentModel.DataAnnotations;

namespace BookSharing.Auth.Data
{
    public class SignUpDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login not specified")]
        [StringLength(50, MinimumLength = 5)]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password not specified")]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string PasswordConfirm { get; set; }
    }
}
