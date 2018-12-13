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
        IssueResultDto Get(int projectId, int id);
        int Create(IssueDto dto);
    }
}
