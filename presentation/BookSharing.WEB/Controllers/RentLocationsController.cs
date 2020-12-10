using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSharing.Interfaces;
using AutoMapper;
using BookSharing.Data;
using BookSharing.Models;

namespace BookSharing.WEB.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class RentLocationsController : Controller
    {
        private readonly IRentLocationRepository rentLocationRepository;
        private readonly IMapper mapper;

        public RentLocationsController(IRentLocationRepository rentLocationRepository, IMapper mapper)
        {
            this.rentLocationRepository = rentLocationRepository;
            this.mapper = mapper;
        }

        // GET: api/locations/
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<RentLocationDto>>> GetAllRentLocationsAsync()
        {
            var location = await rentLocationRepository.GetAllAsync();
            var locationResult = mapper.Map<IEnumerable<RentLocationDto>>(location);

            return Ok(locationResult);
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

        // POST: api/locations/
        [HttpPost("")]
        public async Task<ActionResult<RentLocationDto>> CreateRentLocation(RentLocationDto location)
        {
            if (location == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var locationResult = mapper.Map<RentLocation>(location);

            await rentLocationRepository.AddAsync(locationResult);

            return CreatedAtAction("GetRentLocationByIdAsync", new { id = location.Id }, location);
        }

        // PUT: api/locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentLocationAsync(int id, RentLocationDto location)
        {
            if (id != location.Id) return BadRequest();

            var locationResult = mapper.Map<RentLocation>(location);

            await rentLocationRepository.UpdateAsync(locationResult);
            
            return NoContent();
        }

        // DELETE: api/locations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentLocationDto>> DeleteRentLocation(int id)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);

            if (location == null || location.Id != id) return NotFound();

            await rentLocationRepository.DeleteAsync(location);

            return NoContent();
        }
    }
}
