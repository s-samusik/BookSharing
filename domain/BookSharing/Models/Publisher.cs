using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class Publisher
    {
        private readonly PublisherDto dto;

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

        internal Publisher(PublisherDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static PublisherDto Create(string name)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
                #endregion

                return new PublisherDto { Name = name };
            }
        }

        public static class Mapper
        {
            public static Publisher Map(PublisherDto dto) => new Publisher(dto);
            public static PublisherDto Map(Publisher domain) => domain.dto;
        }
    }
}
