using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public string CreatedBy { get; set; }
        public int ProjectId { get; set; }
        public string IssueTypeId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Project Project { get; set; }
        public virtual IssueType IssueType { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
