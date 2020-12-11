using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BookSharing.Data.EF
{
    class DbContextFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public BookSharingDbContext Create(Type repositoryType)
        {
            var services = httpContextAccessor.HttpContext.RequestServices;
            var dbContexts = services.GetService<Dictionary<Type, BookSharingDbContext>>();
            
            if (!dbContexts.ContainsKey(repositoryType))
                dbContexts[repositoryType] = services.GetService<BookSharingDbContext>();

            return dbContexts[repositoryType];
        }
    }
}
