using AutoMapper;
using BookSharing.Data;
using BookSharing.Models;

namespace BookSharing.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserReadDto>();

            CreateMap<UserTypeCreateDto, UserType>();
            CreateMap<UserType, UserTypeReadDto>();

            CreateMap<RentLocationDto, RentLocation>();
            CreateMap<RentLocation, RentLocationDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<Genre, GenreDto>();
            CreateMap<PublisherDto, Publisher>();
            CreateMap<Publisher, PublisherDto>();
        }
    }
}
