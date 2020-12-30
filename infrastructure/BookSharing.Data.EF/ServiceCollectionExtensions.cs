using BookSharing.Data.EF.Repositories;
using BookSharing.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BookSharing.Data.EF
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookSharingDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                },
                ServiceLifetime.Transient
            );

            services.AddScoped<Dictionary<Type, BookSharingDbContext>>();
            services.AddSingleton<DbContextFactory>();

            services.AddSingleton<IRentLocationRepository, RentLocationRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IBookRepository,BookRepository>();

            return services;
        }
    }
}
