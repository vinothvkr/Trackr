using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
