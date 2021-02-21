using BookSharing.Interfaces;
using BookSharing.Models;
using BookSharing.Services;
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

            var userTypeId = await context.UserTypes
                                          .Where(x => x.Name == "Client")
                                          .Select(x => x.Id)
                                          .FirstOrDefaultAsync();
            if (userTypeId == 0)
            {
                UserType userType = new UserType
                {
                    Name = "Client"
                };

                await context.UserTypes.AddAsync(userType);
                await context.SaveChangesAsync();

                userTypeId = userType.Id;
            }

            user.UserTypeId = userTypeId;

            var hashSalt = UserService.EncryptPassword(user.Password);
            user.Password = hashSalt.Hash;
            user.StoredSalt = hashSalt.Salt;

            await context.UserTypes.Where(x => x.Id == userTypeId).LoadAsync();
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
                                     .Include(x => x.UserType)
                                     .Where(x => x.UserType.Id == type.Id)
                                     .ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var user = await context.Users
                                    .Include(x => x.UserType)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetAllByRequestAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var users = await context.Users
                                     .Include(x => x.UserType)
                                     .Where(x => x.Nickname.Contains(query)
                                              || x.PhoneNumber.Contains(query)
                                              || x.Email.Contains(query))
                                     .ToListAsync();
            return users;
        }

        public async Task<User> GetByRequestAsync(string login, string password)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var user = await context.Users
                                    .Include(x => x.UserType)
                                    .Where(x => x.Nickname == login
                                             || x.PhoneNumber == login
                                             || x.Email == login)
                                    .SingleOrDefaultAsync();

            var isPasswordMatched = UserService.VerifyPassword(password, user.StoredSalt, user.Password);

            return isPasswordMatched ? user : null;
        }

        public async Task<UserType> GetUserTypeByRequestAsync(string query)
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var userType = await context.UserTypes
                                        .Where(x => x.Name.Contains(query))
                                        .FirstOrDefaultAsync();
            return userType;
        }

        public async Task<List<UserType>> GetAllUserTypesAsync()
        {
            var context = dbContextFactory.Create(typeof(UserRepository));

            var userTypes = await context.UserTypes.ToListAsync();

            return userTypes;
        }
    }
}
