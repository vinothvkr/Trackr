using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Dtos.Identity;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class IdentityService : Service<ApplicationUser>, IIdentityService
    {
        public readonly TrackrDbContext _dbContext;
        public readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(TrackrDbContext dbContext,
            UserManager<ApplicationUser> userManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Create(SignupDto m)
        {
            var user = new ApplicationUser
            {
                Email = m.Email,
                UserName = m.Email
            };
            var result = await _userManager.CreateAsync(user, m.Password);
            return result;
        }
    }
}
