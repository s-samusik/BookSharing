using BookSharing.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.Data.EF.Repositories
{
    class RentLocationRepository : IRentLocationRepository
    {
        private readonly DbContextFactory dbContextFactory;

        public RentLocationRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public Task AddAsync(RentLocationDto location)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(RentLocationDto location)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<RentLocationDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<RentLocationDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(RentLocationDto location)
        {
            throw new System.NotImplementedException();
        }
    }
}
