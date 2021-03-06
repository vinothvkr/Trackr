﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Dtos.Identity;
using Trackr.Infrastructure.Services;

namespace Trackr.Infrastructure.Configurations
{
    public class ServiceConfiguration
    {
        public static void ConfigurationService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IIssueTypeService, IssueTypeService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Validators
            services.AddTransient<IValidator<SignupDto>, SignupValidator>();
        }
    }
}
