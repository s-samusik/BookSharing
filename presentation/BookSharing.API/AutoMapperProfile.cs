using AutoMapper;
using BookSharing.Auth.Data;
using BookSharing.Data;
using BookSharing.Models;
using Microsoft.AspNetCore.Http;

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

            CreateMap<SignUpDto, User>();

            CreateMap<IFormFile, byte[]>().ConvertUsing<IFormFileTypeConverter>();
            CreateMap<byte[], string>().ConvertUsing<ByteTypeConverter>();
        }
    }
}
