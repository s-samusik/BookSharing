using BookSharing.Auth;
using BookSharing.Auth.Data;
using BookSharing.Interfaces;
using BookSharing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        //GET: api/auth/test
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("test - ok");
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] SignInDto request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await userRepository.GetByRequestAsync(request.Login, request.Password);

            if (user == null) return Unauthorized();

            var token = GenerateJWT(user);

            return Ok(new { access_token = token });
        }

        private string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Nickname),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Nbf, user.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Typ, user.UserType.Name)
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                                             authParams.Audience,
                                             claims,
                                             expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
