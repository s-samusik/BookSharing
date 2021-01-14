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

        // GET: api/locations/
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RentLocationDto>>> GetAllRentLocationsAsync()
        {
            var locations = await rentLocationRepository.GetAllAsync();
            var locationsResult = mapper.Map<IEnumerable<RentLocationDto>>(locations);

            return Ok(locationsResult);
        }

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
