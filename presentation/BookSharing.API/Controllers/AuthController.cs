using AutoMapper;
using BookSharing.Auth;
using BookSharing.Auth.Data;
using BookSharing.Interfaces;
using BookSharing.Models;
using BookSharing.Services;
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
        /// Accept login and password and return a token if the user is found. The login can be mail or phone number.
        /// </summary>
        /// <param name="signInDto"></param>
        /// <returns></returns>
        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] SignInDto signInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await userRepository.GetByLoginAsync(signInDto.Login, signInDto.Password);

            if (user == null)
            {
                return NotFound(signInDto);
            }

            var token = authOptions.Value.GenerateJWT(user);

            return Ok(new { access_token = token });
        }

        /// <summary>
        /// Create a new client and return a token for this user.
        /// </summary>
        /// <param name="signUpDto"></param>
        /// <returns></returns>
        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] SignUpDto signUpDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UserRegistrationService.IsLoginIncorrect(signUpDto.Login))
            {
                return BadRequest($"login '{signUpDto.Login}' is incorrect");
            }

            if (await userRepository.VerifyLoginAsync(signUpDto.Login))
            {
                return BadRequest($"Login {signUpDto.Login} is already in use");
            }

            var user = userRepository.CreateByLogin(signUpDto.Login, signUpDto.Password);
            await userRepository.AddAsync(user);

            var token = authOptions.Value.GenerateJWT(user);

            return Ok(new { access_token = token });
        }
    }
}
