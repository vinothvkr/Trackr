using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Data;

namespace Trackr.Infrastructure.Configurations
{
    public class DbContextConfiguration
    {
        public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrackrDbContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
