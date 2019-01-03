using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.IdentityServer;

namespace Trackr.Infrastructure.Configurations
{
    public class IdentityServerConfiguration
    {
        public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServer()
            .AddInMemoryClients(Clients.Get())
            .AddInMemoryApiResources(Resources.GetApiResources())
            .AddTestUsers(Users.Get())
            .AddDeveloperSigningCredential();
        }
    }
}
