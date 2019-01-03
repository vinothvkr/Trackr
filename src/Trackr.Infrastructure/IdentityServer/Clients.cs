using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.IdentityServer
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "TrackrWebClient",
                    ClientName = "Trackr web client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("ClientSecret".Sha256())
                    },
                    AllowedScopes = new List<string> {"TrackrAPI.read"},
                    AccessTokenLifetime = 60
                }
            };
        }
    }
}
