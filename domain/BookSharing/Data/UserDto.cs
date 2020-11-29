namespace BookSharing.Data
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }

        public virtual UserTypeDto UserType { get; set; }
        public virtual BookDto Book { get; set; }
        public virtual RentLocationDto RentLocation { get; set; }
    }
}
