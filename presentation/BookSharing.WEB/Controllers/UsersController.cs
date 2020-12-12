using AutoMapper;
using BookSharing.Data;
using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.WEB.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        // POST: api/users/
        [HttpPost("")]
        public async Task<ActionResult<UserDto>> CreateUserAsync(UserDto user)
        {
            if (user == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userResult = mapper.Map<User>(user);

            await userRepository.AddAsync(userResult);

            return CreatedAtAction("GetUserByIdAsync", new { id = user.Id }, user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsync(int id, UserDto user)
        {
            if (id != user.Id) return BadRequest();

            var userResult = mapper.Map<User>(user);

            await userRepository.UpdateAsync(userResult);

            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null || user.Id != id) return NotFound();

            await userRepository.DeleteAsync(user);

            return NoContent();
        }


        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var userResult = mapper.Map<UserDto>(user);

            return userResult;
        }

        //GET: api/users/by_query/"nickname or email or phone number"
        [HttpGet("by_query/{query}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersByQueryAsync(string query)
        {
            var users = await userRepository.GetAllByQueryAsync(query);
            var usersResult = mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersResult);
        }

        //GET: api/users/by_type/"user type"
        [HttpGet("by_type/{userType}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsersByTypeAsync(string userType)
        {
            var type = await userRepository.GetUserTypeByQueryAsync(userType);

            if (type == null) return NotFound(type);

            var users = await userRepository.GetAllByTypeAsync(type);
            var usersResult = mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersResult);
        }
    }
}
