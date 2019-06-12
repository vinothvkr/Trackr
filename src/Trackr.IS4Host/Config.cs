using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Trackr.IS4Host.Config
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "TrackrWebClient",
                    ClientName = "Trackr web client",
                    //AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    //AllowedGrantTypes = GrantTypes.Code,
                    AllowedGrantTypes =
                    {
                        GrantType.AuthorizationCode,
                        GrantType.ResourceOwnerPassword
                    },
                    RequirePkce = true,
                    RequireClientSecret = false,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("ClientSecret".Sha256())
                    },
                    AllowedScopes = new List<string> {"openid", "profile", "TrackrAPI"},
                    AccessTokenLifetime = 3600,
                    RedirectUris = new List<string> { "https://localhost:51866/auth-callback" },
                    PostLogoutRedirectUris = new List<string> { "https://localhost:51866" },
                    AllowedCorsOrigins = new List<string> { "https://localhost:51866" },
                    AllowAccessTokensViaBrowser = true
                }
            };
        }
    }

    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("TrackrAPI", "Trackr Api")
            };
        }
    }

    internal class Users
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
                        new Claim(JwtClaimTypes.Email, "vinothvkr@hotmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
