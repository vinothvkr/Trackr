using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class IssueService : Service<Issue>, IIssueService
    {
        private readonly TrackrDbContext _dbContext;
        public IssueService(TrackrDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Issue> GetAll(int projectId)
        {
            return _dbContext.Issues.Where(m => m.ProjectId == projectId).ToList();
        }
    }
}
