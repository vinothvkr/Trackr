﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.EntityConfigurations;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Data
{
    public class TrackrDbContext : IdentityDbContext<ApplicationUser>
    {
        public TrackrDbContext(DbContextOptions<TrackrDbContext> options)
            :base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new IssueConfiguration());
            builder.ApplyConfiguration(new IssueTypeConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
