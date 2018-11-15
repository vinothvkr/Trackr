using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Data
{
    public class TrackrDbContext : DbContext
    {
        public TrackrDbContext(DbContextOptions<TrackrDbContext> options)
            :base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
