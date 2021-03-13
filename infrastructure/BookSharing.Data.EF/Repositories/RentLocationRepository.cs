using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(RentLocation location)
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));

            await context.RentLocations.AddAsync(location);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RentLocation location)
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));

            context.Entry(location).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RentLocation location)
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));

            context.RentLocations.Remove(location);
            await context.SaveChangesAsync();
        }

        public async Task<List<RentLocation>> GetAllAsync()
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));

            var locations = await context.RentLocations.ToListAsync();

            return locations;
        }

        public async Task<RentLocation> GetByIdAsync(int id)
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));

            var location = await context.RentLocations.FindAsync(id);
            
            return location;
        }

        public async Task<int> CountAsync()
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));

            var count = await context.RentLocations.CountAsync();

            return count;
        }
    }
}
