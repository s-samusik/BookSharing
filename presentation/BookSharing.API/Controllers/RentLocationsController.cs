using AutoMapper;
using BookSharing.Data;
using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSharing.API.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class RentLocationsController : ControllerBase
    {
        private readonly IRentLocationRepository rentLocationRepository;
        private readonly IMapper mapper;

        public RentLocationsController(IRentLocationRepository rentLocationRepository, IMapper mapper)
        {
            this.rentLocationRepository = rentLocationRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Add new location to database.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        // POST: api/locations/
        [HttpPost("")]
        [Authorize]
        public async Task<ActionResult<RentLocationDto>> CreateRentLocationAsync(RentLocationDto location)
        {
            if (location == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var locationResult = mapper.Map<RentLocation>(location);

            await rentLocationRepository.AddAsync(locationResult);

            return CreatedAtAction("GetRentLocationByIdAsync", new { id = location.Id }, location);
        }

        /// <summary>
        /// Change existing location from database.
        /// </summary>
        /// <param name="id">existing location.</param>
        /// <param name="location"></param>
        /// <returns></returns>
        // PUT: api/locations/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutRentLocationAsync(int id, RentLocationDto location)
        {
            if (id != location.Id) return BadRequest();

            var locationResult = mapper.Map<RentLocation>(location);

            await rentLocationRepository.UpdateAsync(locationResult);

            return NoContent();
        }

        /// <summary>
        /// Removes existing location from database.
        /// </summary>
        /// <param name="id">existing location.</param>
        /// <returns></returns>
        // DELETE: api/locations/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<RentLocationDto>> DeleteRentLocationAsync(int id)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);

            if (location == null || location.Id != id) return NotFound();

            await rentLocationRepository.DeleteAsync(location);

            return NoContent();
        }

        /// <summary>
        /// Return all rent locations from database.
        /// </summary>
        /// <returns></returns>
        // GET: api/locations/
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RentLocationDto>>> GetAllRentLocationsAsync()
        {
            var locations = await rentLocationRepository.GetAllAsync();
            var locationsResult = mapper.Map<IEnumerable<RentLocationDto>>(locations);

            return Ok(locationsResult);
        }

        /// <summary>
        /// Return rent location from database with the specified id.
        /// </summary>
        /// <param name="id">existing location.</param>
        /// <returns></returns>
        // GET: api/locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentLocationDto>> GetRentLocationByIdAsync(int id)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);
            if (location == null) return NotFound();

            var locationResult = mapper.Map<RentLocationDto>(location);

            return locationResult;
        }
    }
}
