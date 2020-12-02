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
    }
}
