using BookSharing.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookSharing.Auth
{
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int TokenLifeTime { get; set; } // in seconds


        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }

        public string GenerateJWT(User user)
        {
            var securityKey = GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Nickname),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim ("role", user.UserType.Name)
            };

            var token = new JwtSecurityToken(Issuer,
                                             Audience,
                                             claims,
                                             expires: DateTime.Now.AddSeconds(TokenLifeTime),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
