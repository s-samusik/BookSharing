using BookSharing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);

        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllByRequestAsync(string request);
        Task<User> GetByRequestAsync(string login, string password);
        Task<UserType> GetUserTypeByRequestAsync(string request);
        Task<List<User>> GetAllByTypeAsync(UserType type);
    }
}
