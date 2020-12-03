using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class Author
    {
        private readonly AuthorDto dto;

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

        internal Author(AuthorDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static AuthorDto Create(string name)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
                #endregion

                return new AuthorDto
                {
                    Name = name,
                };
            }
        }

        public static class Mapper
        {
            public static Author Map(AuthorDto dto) => new Author(dto);
            public static AuthorDto Map(Author domain) => domain.dto;
        }
    }
}
