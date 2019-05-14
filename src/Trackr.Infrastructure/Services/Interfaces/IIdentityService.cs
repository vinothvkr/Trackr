using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trackr.Infrastructure.Dtos.Identity;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public interface IIdentityService : IService<ApplicationUser>
    {
        Task<IdentityResult> Create(SignupDto m);
    }
}
