using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Dtos.Issue
{
    public class IssueDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IssueTypeId { get; set; }
        public int ProjectId { get; set; }
    }
}
