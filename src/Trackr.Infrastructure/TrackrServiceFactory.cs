using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Configurations;

namespace Trackr.Infrastructure
{
    public class TrackrServiceFactory
    {
        public IConfiguration Configuration { get; set; }
        public TrackrServiceFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ServiceConfigurations(IServiceCollection services)
        {
            IdentityServerConfiguration.ConfigurationService(services, Configuration);
            DbContextConfiguration.ConfigurationService(services, Configuration);
            IdentityConfiguration.ConfigurationService(services, Configuration);
            AuthenticationConfiguration.ConfigurationService(services, Configuration);
            ServiceConfiguration.ConfigurationService(services, Configuration);
        }
    }
}
