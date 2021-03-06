﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Trackr.Api.Filters;
using Trackr.Infrastructure;

namespace Trackr.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            TrackrServiceFactory = new TrackrServiceFactory(Configuration);
        }

        public IConfiguration Configuration { get; }
        public TrackrServiceFactory TrackrServiceFactory { get; }
        readonly string CorsPolicy = "_corsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            TrackrServiceFactory.ServiceConfigurations(services);
            services.AddCors(o =>
            {
                o.AddPolicy(CorsPolicy,
                builder =>
                {
                    builder.WithOrigins(Configuration["Spa:Origins"])
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddMvc(o => 
            {
                o.Filters.Add(typeof(ModelValidatorAttribute));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(CorsPolicy);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
