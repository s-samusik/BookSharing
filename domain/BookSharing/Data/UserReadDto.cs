namespace BookSharing.Data
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserTypeReadDto UserType { get; set; }
    }
}
