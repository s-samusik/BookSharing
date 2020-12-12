using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Data.EF.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly DbContextFactory dbContextFactory;

        public UserRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task AddAsync(User user)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllByTypeAsync(UserType type)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var users = await context.Users
                                     .AsNoTracking()
                                     .Include(x => x.UserType)
                                     .Where(x => x.UserType.Name == type.Name)
                                     .ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var user = await context.Users
                                    .AsNoTracking()
                                    .Include(x => x.UserType)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<List<User>> GetAllByQueryAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var users = await context.Users
                                     .AsNoTracking()
                                     .Include(x => x.UserType)
                                     .Where(a => a.Nickname.Contains(query)
                                              || a.PhoneNumber.Contains(query)
                                              || a.Email.Contains(query))
                                     .ToListAsync();
            return users;
        }

        public async Task<UserType> GetUserTypeByQueryAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var userType = await context.UserTypes
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Name.Contains(query));
            return userType;
        }
    }
}
