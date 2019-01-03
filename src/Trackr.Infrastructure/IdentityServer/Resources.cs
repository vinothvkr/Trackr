using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.IdentityServer
{
    public class Resources
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "TrackrAPI",
                    DisplayName = "Trackr API",
                    Description = "Trackr API Access",
                    UserClaims = new List<string> {"role"},
                    ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                    Scopes = new List<Scope>
                    {
                        new Scope("TrackrAPI.read"),
                        new Scope("TrackrAPI.write")
                    }
                }
            };
        }
    }
}
