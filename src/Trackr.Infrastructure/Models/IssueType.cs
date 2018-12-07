using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Models
{
    public class IssueType
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
