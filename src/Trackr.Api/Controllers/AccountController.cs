using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trackr.Infrastructure.Dtos.Identity;
using Trackr.Infrastructure.Services;

namespace Trackr.Api.Controllers
{
    [Route("api/account/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Signup(SignupDto m)
        {
            var result = await _identityService.Create(m);

            return Ok(result.Succeeded);
        }
    }
}