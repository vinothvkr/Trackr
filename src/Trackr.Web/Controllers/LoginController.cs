using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackr.Infrastructure.Dtos.Identity;
using Trackr.Infrastructure.Services;

namespace Trackr.Web.Controllers
{
    [Route("api/auth/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public LoginController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginDto dto)
        {
            var result = await _identityService.Login(dto);
            if (result.Success)
            {
                return Ok(result.User);
            }
            result.Error.Status = 400;
            return BadRequest(result.Error);
        }
    }
}