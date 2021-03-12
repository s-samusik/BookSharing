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
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, ReadUserDto>();
 
            CreateMap<CreateUserTypeDto, UserType>();
            CreateMap<UserType, ReadUserTypeDto>();

            CreateMap<CreateRentLocationDto, RentLocation>();
            CreateMap<UpdateRentLocationDto, RentLocation>();
            CreateMap<RentLocation, ReadRentLocationDto>();
            
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<Book, ReadBookDto>();

            CreateMap<CreateAuthorDto, Author>();
            CreateMap<Author, ReadAuthorDto>();
            
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<Genre, ReadGenreDto>();
            
            CreateMap<CreatePublisherDto, Publisher>();
            CreateMap<Publisher, ReadPublisherDto>();

            CreateMap<SignUpDto, User>();

            CreateMap<IFormFile, byte[]>().ConvertUsing<IFormFileTypeConverter>();
            CreateMap<byte[], string>().ConvertUsing<ByteTypeConverter>();
        }
    }
}
