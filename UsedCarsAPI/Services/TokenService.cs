using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UsedCarsAPI.Data;
using UsedCarsAPI.Models;

namespace UsedCarsAPI.Services
{
    public class TokenService
    {
        private readonly UsedCarsDBContext _dbContext;

        public TokenService(UsedCarsDBContext usedCarsDBContext)
        {
            _dbContext = usedCarsDBContext;
        }
            
        public async Task<object?> GenerateToken(string email, string password)
        {
            UserModel? foundUser = await _dbContext.Users
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            if (foundUser == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, foundUser.Name.ToString()),
                    new Claim(ClaimTypes.Role, foundUser.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            foundUser.Password = "";
            return new { 
                user = foundUser,
                token = tokenString
            };
        }
    }
}
