using AutoMapper;
using BookSharing.Data;
using BookSharing.Models;

namespace BookSharing.WEB
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RentLocationDto, RentLocation>();
            CreateMap<RentLocation, RentLocationDto>();
        }
    }
}
