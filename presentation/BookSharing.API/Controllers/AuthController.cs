using BookSharing.Auth;
using BookSharing.Auth.Data;
using BookSharing.Interfaces;
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

        public AuthController(IUserRepository userRepository, IOptions<AuthOptions> authOptions)
        {
            this.userRepository = userRepository;
            this.authOptions = authOptions;
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
            if (!ModelState.IsValid) return BadRequest();

            var user = await userRepository.GetByRequestAsync(request.Login, request.Password);

            if (user == null) return Unauthorized();

            var token = authOptions.Value.GenerateJWT(user);

            return Ok(new { access_token = token });
        }
    }
}
