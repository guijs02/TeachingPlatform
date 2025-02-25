using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(User user)

        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("fjdik4343493ADFJFAK933432FDxxs&$#33444fsjdbabaii(9%22")
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
