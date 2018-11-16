using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class ProjectService : Service<Project>, IProjectService
    {
        public readonly TrackrDbContext _dbContext;
        public ProjectService(TrackrDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Project Get(int id)
        {
            return _dbContext.Projects.Include(m => m.Issues).SingleOrDefault(m => m.Id == id);
        }
    }
}
