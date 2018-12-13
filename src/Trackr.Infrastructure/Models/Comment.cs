using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int IssueId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOnUTC { get; set; }

        public Issue Issue { get; set; }
        public ApplicationUser User { get; set; }
    }
}
