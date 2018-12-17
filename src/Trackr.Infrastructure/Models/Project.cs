using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
