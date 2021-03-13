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
    [Authorize(Roles = "Administrator")]

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
        /// <param name="locationDto"></param>
        /// <returns></returns>
        // POST: api/locations/
        [HttpPost("")]
        public async Task<IActionResult> CreateRentLocationAsync(CreateRentLocationDto locationDto)
        {
            if (locationDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var location = mapper.Map<RentLocation>(locationDto);
            await rentLocationRepository.AddAsync(location);
            var locationReadDto = mapper.Map<ReadRentLocationDto>(location);

            return CreatedAtAction(nameof(GetRentLocationByIdAsync), new { id = locationReadDto.Id }, locationReadDto);
        }

        /// <summary>
        /// Change existing location from database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locationDto"></param>
        /// <returns></returns>
        // PUT: api/locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentLocationAsync(int id, [FromBody] UpdateRentLocationDto locationDto)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);

            if (location == null)
            {
                return NotFound(id);
            }

            mapper.Map(locationDto, location);

            await rentLocationRepository.UpdateAsync(location);

            return NoContent();
        }

        /// <summary>
        /// Removes existing location from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentLocationAsync(int id)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);

            if (location == null)
            {
                return NotFound(id);
            }

            await rentLocationRepository.DeleteAsync(location);

            return NoContent();
        }

        /// <summary>
        /// Return all rent locations from database.
        /// </summary>
        /// <returns></returns>
        // GET: api/locations/
        [HttpGet()]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ReadRentLocationDto>>> GetAllRentLocationsAsync()
        {
            var locations = await rentLocationRepository.GetAllAsync();
            var locationsReadDto = mapper.Map<IEnumerable<ReadRentLocationDto>>(locations);

            return Ok(locationsReadDto);
        }

        /// <summary>
        /// Return rent location from database with the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadRentLocationDto>> GetRentLocationByIdAsync(int id)
        {
            var location = await rentLocationRepository.GetByIdAsync(id);
            
            if (location == null)
            {
                return NotFound(id);
            }

            var locationReadDto = mapper.Map<ReadRentLocationDto>(location);

            return Ok(locationReadDto);
        }

        /// <summary>
        /// Count locations from database.
        /// </summary>
        /// <returns></returns>
        // GET: api/locations/count
        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountRentLocationsAsync()
        {
            var count = await rentLocationRepository.CountAsync();

            return Ok(count);
        }
    }
}
