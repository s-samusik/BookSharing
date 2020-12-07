using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var dto = RentLocation.DtoFactory.Create(location.Name, location.Country, location.City,
                                                     location.Street, location.Building);
            context.RentLocations.Add(dto);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RentLocation location)
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));
            await context.SaveChangesAsync();
        }

        public async Task<RentLocation> GetByIdAsync(int id)
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));
            var dto = await context.RentLocations.FindAsync(id);

            return dto == null ? null : RentLocation.Mapper.Map(dto);
        }

        public async Task<List<RentLocation>> GetAllAsync()
        {
            var context = dbContextFactory.Create(typeof(RentLocationRepository));

            var dtos = await context.RentLocations
                                    .AsNoTracking()
                                    .ToListAsync();

            return dtos.Select(RentLocation.Mapper.Map).ToList();
        }
    }
}
