using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Trackr.Infrastructure.IdentityServer
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "vinoth",
                    Password = "pass",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "vinoth@hotmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
