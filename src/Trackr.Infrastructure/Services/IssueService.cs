using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Dtos.Issue;
using Trackr.Infrastructure.Helpers;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class IssueService : Service<Issue>, IIssueService
    {
        private readonly TrackrDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpConext;

        public IssueService(
            TrackrDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContext
            ) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _httpConext = httpContext;
        }

        public IEnumerable<Issue> GetAll(int projectId)
        {
            return _dbContext.Issues.Where(m => m.ProjectId == projectId).ToList();
        }

        public IssueResultDto Get(int projectId, int id)
        {
            Issue i = _dbContext.Issues.Where(m => m.ProjectId == projectId)
                .Where(m => m.Id == id)
                .Include(m => m.IssueType)
                .Include(m => m.Project)
                .Include(m => m.User)
                .FirstOrDefault();

            return new IssueResultDto
            {
                Id = i.Id,
                Title = i.Title,
                CreatedOnUTC = i.CreatedOn,
                Description = i.Description,
                IssueType = i.IssueType.Name,
                Project = new ProjectDto
                {
                    Id = i.Project.Id,
                    Name = i.Project.Name
                },
                User = new UserDto
                {
                    Id = i.User.Id,
                    Fullname = i.User.FullName
                }
            };
        }

        public int Create(IssueDto dto)
        {
            Issue issue = new Issue
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedBy = _httpConext.HttpContext.User.GetUserId(),
                CreatedOn = DateTimeOffset.UtcNow,
                IssueTypeId = dto.IssueTypeId,
                ProjectId = dto.ProjectId
            };
            _dbContext.Issues.Add(issue);
            _dbContext.SaveChanges();
            return issue.Id;
        }
    }
}
