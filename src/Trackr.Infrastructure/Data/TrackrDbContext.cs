using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProjectConfiguration());
        }
    }
}
