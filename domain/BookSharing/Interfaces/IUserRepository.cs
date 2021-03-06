﻿using BookSharing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetAllByRequestAsync(string request);
        Task<User> GetByLoginAsync(string login, string password);
        User CreateByLogin(string login, string password);
        Task<UserType> GetUserTypeByRequestAsync(string request);
        Task<List<User>> GetAllByTypeAsync(UserType type);
        Task<List<UserType>> GetAllUserTypesAsync();
        Task<bool> VerifyLoginAsync(string login);
        Task<int> CountAsync();
    }
}
