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
        public async Task<IActionResult> CreateUserAsync([FromForm] CreateUserDto userDto)
        {
            if (userDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(userDto);
            await userRepository.AddAsync(user);
            var userReadDto = mapper.Map<ReadUserDto>(user);

            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = userReadDto.Id }, userReadDto);
        }

        /// <summary>
        /// Change existing user from database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        // PUT: api/users/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUserAsync(int id, [FromForm] UpdateUserDto userDto)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound(id);
            }

            mapper.Map(userDto, user);

            await userRepository.UpdateAsync(user);

            return NoContent();
        }

        /// <summary>
        /// Remove existing user from database.
        /// </summary>
        /// <param name="id">existing user</param>
        /// <returns></returns>
        // DELETE: api/users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, Librarian")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound(id);
            }

            await userRepository.DeleteAsync(user);

            return NoContent();
        }

        /// <summary>
        /// Return user from database with the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound(id);
            }

            var userReadDto = mapper.Map<ReadUserDto>(user);
            return Ok(userReadDto);
        }

        /// <summary>
        /// Return all users that match the request.
        /// </summary>
        /// <param name="request">nickname or email or phone number</param>
        /// <returns></returns>
        //GET: api/users/search/"nickname or email or phone number"
        [HttpGet("search/{request}")]
        [Authorize(Roles = "Administrator, Librarian")]
        public async Task<ActionResult<IEnumerable<ReadUserDto>>> GetAllUsersByRequestAsync(string request)
        {
            var users = await userRepository.GetAllByRequestAsync(request);
            var usersReadDto = mapper.Map<IEnumerable<ReadUserDto>>(users);

            return Ok(usersReadDto);
        }

        /// <summary>
        /// Return all users of concrete type.
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        //GET: api/users/by_type/"user type"
        [HttpGet("by_type/{userType}")]
        public async Task<ActionResult<IEnumerable<ReadUserDto>>> GetAllUsersByTypeAsync(string userType)
        {
            var type = await userRepository.GetUserTypeByRequestAsync(userType);

            if (type == null)
            {
                return NotFound(type);
            }

            var users = await userRepository.GetAllByTypeAsync(type);
            var usersReadDto = mapper.Map<IEnumerable<ReadUserDto>>(users);

            return Ok(usersReadDto);
        }

        /// <summary>
        /// Return all user tytpes from database.
        /// </summary>
        /// <returns></returns>
        //GET: api/users/types/
        [HttpGet("types")]
        [Authorize(Roles = "Administrator")]
        public async Task <ActionResult<IEnumerable<ReadUserTypeDto>>> GetAllUserTypesAsync()
        {
            var types = await userRepository.GetAllUserTypesAsync();
            var typesReadDto = mapper.Map<IEnumerable<ReadUserTypeDto>>(types);

            return Ok(typesReadDto);
        }
    }
}
