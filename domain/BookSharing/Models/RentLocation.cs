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
        public RentLocationAddress Address
        {
            get => new RentLocationAddress(dto.RentLocationAddress);
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(RentLocationAddress));

                dto.RentLocationAddress.Country = value?.Country.Trim();
                dto.RentLocationAddress.City = value.City.Trim();
                dto.RentLocationAddress.Street = value.Street.Trim();
                dto.RentLocationAddress.Building = value.Building.Trim();
            }
        }
        #endregion

        internal RentLocation(RentLocationDto dto)
        {
            this.dto = dto;
        }

        public static class DtoFactory
        {
            public static RentLocationDto Create(string name, RentLocationAddressDto address)
            {
                #region Checking incoming parameters
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
                if (address == null) throw new ArgumentNullException(nameof(address));
                #endregion

                return new RentLocationDto
                {
                    Name = name,
                    RentLocationAddress = address,
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
