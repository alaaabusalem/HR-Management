﻿using Domain.Models.Auth;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api._Helpers
{
    public class Jwt : IJwt
    {
        private readonly IConfiguration _config;
        private string? key;
        public Jwt(IConfiguration config)
        {
            _config = config;
        }

        public static TokenValidationParameters GetValidationPerameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }

        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secret = configuration["JWT:Secret"];
            if (secret == null)
            {
                throw new InvalidOperationException("JWT: Secret key is not exist");
            }

            var secretBytes = Encoding.UTF8.GetBytes(secret);

            return new SymmetricSecurityKey(secretBytes);
        }
        public string GenerateJwtToken(User user, TimeSpan expiresIn)
        {
            try
            {
                key = _config.GetValue<string>("JWT:Secret");
                if (key != null) {
                    var secretBytes = Encoding.UTF8.GetBytes(key);
                   var signingKey=new SymmetricSecurityKey(secretBytes);

                    // Generate principles

                    var claims = new[]
               {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("Name", (user.Name)),
                    new Claim("Email", (user.Email is not null) ? user.Email: ""),
                    new Claim("Phone", (user.Phone is not null) ? user.Phone : ""),
                    new Claim("Phone", user.RoleList.ToString()),

                };

                    // Generate token
                    var token = new JwtSecurityToken(
                expires: DateTime.UtcNow + expiresIn,
                signingCredentials: new SigningCredentials(signingKey,
                SecurityAlgorithms.HmacSha256),
                claims: claims

                );

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }

            catch {

                return "";
            }
            return "";
        }
    }
}
