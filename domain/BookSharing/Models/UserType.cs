using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class UserType
    {
        private readonly UserTypeDto dto;

        #region Properties
        public int Id => dto.Id;
        public string Name
        {
            get => dto.Name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Name));
                dto.Name = value.Trim();
            }
        }
        #endregion

        internal UserType(UserTypeDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static UserTypeDto Create(string name)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
                #endregion

                return new UserTypeDto { Name = name };
            }
        }

        public static class Mapper
        {
            public static UserType Map(UserTypeDto dto) => new UserType(dto);
            public static UserTypeDto Map(UserType domain) => domain.dto;
        }
    }
}
