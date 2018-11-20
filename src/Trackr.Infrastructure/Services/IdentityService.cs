using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Dtos.Identity;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly TrackrDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public IdentityService(TrackrDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<LoginResultDto> Login(LoginDto dto)
        {
            var identity = await GetClaimsIdentity(dto.Email, dto.Password);
            LoginResultDto result = new LoginResultDto();
            if (identity == null)
            {
                return result;
            }
            var token = GenerateToken(dto.Email, identity);
            result.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            if (await _userManager.CheckPasswordAsync(user, password))
            {
                return await Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.UserName, "Token")));
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }

        private JwtSecurityToken GenerateToken(string userName, ClaimsIdentity identity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
