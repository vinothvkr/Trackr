using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trackr.Infrastructure.Dtos.Identity;

namespace Trackr.Infrastructure.Services
{
    public interface IIdentityService
    {
        Task<LoginResultDto> Login(LoginDto dto);
    }
}
