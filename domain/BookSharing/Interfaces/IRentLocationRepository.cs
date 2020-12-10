using BookSharing.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IRentLocationRepository
    {
        Task AddAsync(RentLocationDto location);
        Task UpdateAsync(RentLocationDto location);
        Task DeleteAsync(RentLocationDto location);

        Task<RentLocationDto> GetByIdAsync(int id);
        Task<List<RentLocationDto>> GetAllAsync();
    }
}
