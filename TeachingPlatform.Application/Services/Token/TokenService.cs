using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeachingPlatform.Application.Services.Interfaces;

namespace TeachingPlatform.Application.Services.Token
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        private readonly IConfiguration _config = config;

        public string GenerateToken(Domain.Entities.User user)

        {
            var secretKey = _config["JwtSettings:SecretKey"];

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey)
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("id", user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.TypeOfUser.ToString()),
                    ]
                ),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };

            //retorna o token em forma de cadeia de caracteres
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
