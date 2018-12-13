using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Dtos.Issue
{
    public class IssueResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public UserDto User { get; set; }
        public string IssueType { get; set; }
        public ProjectDto Project { get; set; }
    }

    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserDto
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
    }
}
