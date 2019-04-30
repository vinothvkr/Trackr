using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Configurations
{
    public class AuthenticationConfiguration
    {
        public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
            .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, o =>
            {
                o.Authority = "https://localhost:51864/";
                o.ApiName = "TrackrAPI";
            });
        }
    }
}
