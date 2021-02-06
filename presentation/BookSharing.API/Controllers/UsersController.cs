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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Add new user to database.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        // POST: api/users/
        [HttpPost("")]
        [Authorize]
        public async Task<ActionResult<UserCreateDto>> CreateUserAsync(UserCreateDto userDto)
        {
            if (userDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(userDto);

            await userRepository.AddAsync(user);
            
            var userReadDto = mapper.Map<UserReadDto>(user);

            return CreatedAtAction("GetUserByIdAsync", new { id = userReadDto.Id }, userReadDto);
        }

        /// <summary>
        /// Change existing user from database.
        /// </summary>
        /// <param name="id">existing user</param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsync(int id, [FromBody]UserReadDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            var user = mapper.Map<User>(userDto);

            await userRepository.UpdateAsync(user);

            return Ok();
        }

        /// <summary>
        /// Remove existing user from database.
        /// </summary>
        /// <param name="id">existing user</param>
        /// <returns></returns>
        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCreateDto>> DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null || user.Id != id) return NotFound();

            await userRepository.DeleteAsync(user);

            return NoContent();
        }

        /// <summary>
        /// Return user from database with the specified id.
        /// </summary>
        /// <param name="id">existing user</param>
        /// <returns></returns>
        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCreateDto>> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }

            var userReadDto = mapper.Map<UserReadDto>(user);

            return Ok(userReadDto);
        }

        /// <summary>
        /// Return all users that match the request.
        /// </summary>
        /// <param name="request">nickname or email or phone number</param>
        /// <returns></returns>
        //GET: api/users/search/"nickname or email or phone number"
        [HttpGet("search/{request}")]
        public async Task<ActionResult<IEnumerable<UserCreateDto>>> GetAllUsersByRequestAsync(string request)
        {
            var users = await userRepository.GetAllByRequestAsync(request);
            var usersResult = mapper.Map<IEnumerable<UserCreateDto>>(users);

            return Ok(usersResult);
        }

        /// <summary>
        /// Return all users of concrete type.
        /// </summary>
        /// <param name="userType">user type</param>
        /// <returns></returns>
        //GET: api/users/by_type/"user type"
        [HttpGet("by_type/{userType}")]
        public async Task<ActionResult<IEnumerable<UserCreateDto>>> GetAllUsersByTypeAsync(string userType)
        {
            var type = await userRepository.GetUserTypeByRequestAsync(userType);

            if (type == null) return NotFound(type);

            var users = await userRepository.GetAllByTypeAsync(type);
            var usersResult = mapper.Map<IEnumerable<UserCreateDto>>(users);

            return Ok(usersResult);
        }
    }
}
