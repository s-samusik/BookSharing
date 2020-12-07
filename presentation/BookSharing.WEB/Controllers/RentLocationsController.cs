using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSharing.Interfaces;
using BookSharing.Models;

namespace BookSharing.WEB.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class RentLocationsController : Controller
    {
        private readonly IRentLocationRepository rentLocationRepository;

        public RentLocationsController(IRentLocationRepository rentLocationRepository)
        {
            this.rentLocationRepository = rentLocationRepository;
        }

        // POST: api/locations/
        [HttpPost("")]
        public async Task<ActionResult<RentLocation>> CreateRentLocation([FromBody] RentLocation location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await rentLocationRepository.AddAsync(location);
            return Ok(location);
        }

        // GET: api/locations/
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RentLocation>>> GetAllRentLocations()
        {
            var location = await rentLocationRepository.GetAllAsync();
            return location;
        }

        // GET: api/locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentLocation>> GetRentLocationById(int id)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);
            return location == null ? NotFound() : (ActionResult<RentLocation>)location;
        }

        // DELETE: api/locations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentLocation>> DeleteRentLocation(int id)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);
            if (location == null)
                return NotFound();

            await rentLocationRepository.UpdateAsync(location);
            return NoContent();
        }
    }
}
