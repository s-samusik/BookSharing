using BookSharing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IRentLocationRepository
    {
        Task AddAsync(RentLocation location);
        Task UpdateAsync(RentLocation location);
        Task DeleteAsync(RentLocation location);
        Task<RentLocation> GetByIdAsync(int id);
        Task<List<RentLocation>> GetAllAsync();
    }
}
