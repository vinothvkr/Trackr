using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class ProjectService : Service<Project>, IProjectService
    {
        public ProjectService(TrackrDbContext dbContext) : base(dbContext)
        {
        }
    }
}
