using AutoMapper;
using BookSharing.Auth;
using BookSharing.Auth.Data;
using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BookSharing.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IOptions<AuthOptions> authOptions;
        private readonly IMapper mapper;

        public AuthController(IUserRepository userRepository, IOptions<AuthOptions> authOptions, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.authOptions = authOptions;
            this.mapper = mapper;
        }

        /// <summary>
        /// Accept login and password and return a token if the user is found. The login can be nickname, mail or phone number.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] SignInDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await userRepository.GetByRequestAsync(request.Login, request.Password);

            if (user == null)
            {
                return NotFound();
            }

            var token = authOptions.Value.GenerateJWT(user);

            return Ok(new { access_token = token });
        }

        /// <summary>
        /// Create a new client and return a token for this user.
        /// </summary>
        /// <param name="signUpDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] SignUpDto signUpDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = mapper.Map<User>(signUpDto);
            await userRepository.AddAsync(user);

            var token = authOptions.Value.GenerateJWT(user);

            return Ok(new { access_token = token });
        }
    }
}
