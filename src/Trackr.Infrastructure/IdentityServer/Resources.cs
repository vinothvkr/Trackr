using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.IdentityServer
{
    public class Resources
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
}
