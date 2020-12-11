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
        Task<User> GetByQueryAsync(string query);
        Task<UserType> GetUserTypeByQueryAsync(string query);
        Task<List<User>> GetAllByTypeAsync(UserType type);
    }
}
