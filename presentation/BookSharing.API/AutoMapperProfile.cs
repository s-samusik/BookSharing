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

            CreateMap<RentLocationCreateDto, RentLocation>();
            CreateMap<RentLocationUpdateDto, RentLocation>();
            CreateMap<RentLocation, RentLocationReadDto>();
            
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<Book, BookReadDto>();

            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorReadDto>();
            
            CreateMap<GenreCreateDto, Genre>();
            CreateMap<Genre, GenreReadDto>();
            
            CreateMap<PublisherCreateDto, Publisher>();
            CreateMap<Publisher, PublisherReadDto>();
        }
    }
}
