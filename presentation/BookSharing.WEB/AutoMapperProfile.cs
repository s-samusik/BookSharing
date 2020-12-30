using AutoMapper;
using BookSharing.Data;
using BookSharing.Models;

namespace BookSharing.WEB
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RentLocationDto, RentLocation>();
            CreateMap<RentLocation, RentLocationDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserTypeDto, UserType>();
            CreateMap<User, UserDto>();
            CreateMap<UserType, UserTypeDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<AuthorDto,Author>();
            CreateMap<Author,AuthorDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<Genre,GenreDto>();
            CreateMap<PublisherDto,Publisher>();
            CreateMap<Publisher,PublisherDto>();
        }
    }
}
