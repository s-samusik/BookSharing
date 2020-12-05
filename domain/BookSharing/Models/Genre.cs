using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class Genre
    {
        private readonly GenreDto dto;

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

        internal Genre(GenreDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static GenreDto Create(string name)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
                #endregion

                return new GenreDto { Name = name };
            }
        }

        public static class Mapper
        {
            public static Genre Map(GenreDto dto) => new Genre(dto);
            public static GenreDto Map(Genre domain) => domain.dto;
        }

    }
}
