using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Persistance.DbContext;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.Persistance.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IFileService fileService) : base(context, fileService)
        {
        }

        public Task CreateToken(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var claims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
             

            };
            var SecurityKey = Environment.GetEnvironmentVariable("SecretKey");
            var Isuure = Environment.GetEnvironmentVariable("Issuer");
            var key = Encoding.UTF8.GetBytes(SecurityKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = signingCredentials,
                Issuer = Isuure,
                NotBefore = DateTime.UtcNow
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(securityToken));

        }
    }
}
