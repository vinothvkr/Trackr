using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Dtos.Identity
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
