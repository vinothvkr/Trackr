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
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService;

        public LoginController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]LoginDto dto)
        {
            return Json(await _identityService.Login(dto));
        }
    }
}