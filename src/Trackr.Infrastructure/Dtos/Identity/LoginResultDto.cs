using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Dtos.Identity
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
