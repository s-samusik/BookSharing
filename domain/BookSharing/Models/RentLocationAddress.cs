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
    }
}
