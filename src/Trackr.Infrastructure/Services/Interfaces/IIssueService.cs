using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Dtos.Issue;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public interface IIssueService : IService<Issue>
    {
        IEnumerable<Issue> GetAll(int projectId);
        int Create(IssueDto dto);
    }
}
