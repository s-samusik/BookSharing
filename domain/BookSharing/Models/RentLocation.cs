using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class RentLocation
    {
        private readonly RentLocationDto dto;

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
        public string Country
        {
            get => dto.Country;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Country));
                dto.Country = value.Trim();
            }
        }
        public string City
        {
            get => dto.City;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(City));
                dto.City = value.Trim();
            }
        }
        public string Street
        {
            get => dto.Street;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Street));
                dto.Street = value.Trim();
            }
        }
        public string Building
        {
            get => dto.Building;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(Building));
                dto.Building = value.Trim();
            }
        }
        #endregion

        internal RentLocation(RentLocationDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static RentLocationDto Create(string name, string country, string city, string street, string building)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
                if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException(nameof(country));
                if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException(nameof(city));
                if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException(nameof(street));
                if (string.IsNullOrWhiteSpace(building)) throw new ArgumentException(nameof(building));
                #endregion

                return new RentLocationDto
                {
                    Name = name,
                    Country = country,
                    City = city,
                    Street = street,
                    Building = building
                };
            }
        }

        public static class Mapper
        {
            public static RentLocation Map(RentLocationDto dto) => new RentLocation(dto);
            public static RentLocationDto Map(RentLocation domain) => domain.dto;
        }
    }
}
