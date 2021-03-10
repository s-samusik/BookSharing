namespace BookSharing.Data
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ReadUserTypeDto UserType { get; set; }
    }
}
