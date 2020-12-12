namespace BookSharing.Data
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserTypeDto UserType { get; set; }
    }
}
