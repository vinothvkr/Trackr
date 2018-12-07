using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class IssueTypeService : Service<IssueType>, IIssueTypeService
    {
        public IssueTypeService(TrackrDbContext dbContext) : base(dbContext)
        {
        }
    }
}
