using System.ComponentModel.DataAnnotations;

namespace BookSharing.Auth.Data
{
    public class SignInDto
    {
        [Required]
        public string Login { get; set; }
       
        [Required]
        public string Password  { get; set; }
    }
}
