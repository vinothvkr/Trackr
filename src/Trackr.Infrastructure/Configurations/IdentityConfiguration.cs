using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Configurations
{
    public class IdentityConfiguration
    {
        public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TrackrDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
