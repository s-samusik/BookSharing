using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class User
    {
        private readonly UserDto dto;

        #region Properties
        public int Id => dto.Id;
        public string Nickname
        {
            get => dto.Nickname;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Nickname));
                dto.Nickname = value.Trim();
            }
        }
        public string Email
        {
            get => dto.Email;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Email));
                dto.Email = value.Trim();
            }
        }
        public string PhoneNumber
        {
            get => dto.PhoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(PhoneNumber));
                dto.PhoneNumber = value.Trim();
            }
        }
        public string Password
        {
            get => dto.Password;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Password));
                dto.Password = value.Trim();
            }
        }
        public UserType UserType
        {
            get => new UserType(dto.UserType);
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(UserType));
                dto.UserType.Id = value.Id;
            }
        }
        public Book Book
        {
            get => new Book(dto.Book);
            set => dto.Book.Id = value.Id;
        }
        #endregion

        internal User(UserDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static UserDto Create(string nickname, string email, string phoneNumber, string password, UserTypeDto userType)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(nickname)) throw new ArgumentException(nameof(nickname));
                if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException(nameof(email));
                if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentException(nameof(phoneNumber));
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException(nameof(password));
                if (userType == null) throw new ArgumentNullException(nameof(userType));
                #endregion

                return new UserDto
                {
                    Nickname = nickname,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Password = password,
                    UserType = userType,
                };
            }
        }

        public static class Mapper
        {
            public static User Map(UserDto dto) => new User(dto);
            public static UserDto Map(User domain) => domain.dto;
        }
    }
}
