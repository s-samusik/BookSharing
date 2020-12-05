using BookSharing.Data;
using System;

namespace BookSharing.Models
{
    public class RentLocationAddress
    {
        private readonly RentLocationAddressDto dto;

        #region Properties
        public int Id => dto.Id;
        public string Country
        {
            get => dto.Country;
            set => dto.Country = value?.Trim();
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

        internal RentLocationAddress(RentLocationAddressDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static RentLocationAddressDto Create(RentLocationDto rentLocation, string country, string city, string street, string building)
            {
                #region Checking incoming parameters
                if (rentLocation == null) throw new ArgumentNullException(nameof(rentLocation));
                if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException(nameof(city));
                if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException(nameof(street));
                if (string.IsNullOrWhiteSpace(building)) throw new ArgumentException(nameof(building));
                #endregion

                return new RentLocationAddressDto
                {
                    Country = country,
                    City = city,
                    Street = street,
                    Building = building,
                };
            }
        }

        public static class Mapper
        {
            public static RentLocationAddress Map(RentLocationAddressDto dto) => new RentLocationAddress(dto);
            public static RentLocationAddressDto Map(RentLocationAddress domain) => domain.dto;
        }
    }
}
