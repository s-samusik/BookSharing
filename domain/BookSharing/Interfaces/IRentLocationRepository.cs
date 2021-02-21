using BookSharing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Interfaces
{
    public interface IRentLocationRepository : IBaseRepository<RentLocation>
    {
        Task<List<RentLocation>> GetAllAsync();
    }
}
