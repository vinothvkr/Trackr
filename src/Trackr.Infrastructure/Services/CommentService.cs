using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trackr.Infrastructure.Data;
using Trackr.Infrastructure.Dtos.Comment;
using Trackr.Infrastructure.Helpers;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly TrackrDbContext _dbContext;
        private readonly HttpContext _httpContext;

        public CommentService(
            TrackrDbContext dbContext,
            IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext.HttpContext;
        }
        public IEnumerable<CommentResultDto> GetAll(int projectId, int issueId)
        {
            var issue = _dbContext.Issues.Where(m => m.Id == issueId)
                .Where(m => m.ProjectId == projectId)
                .Include(m => m.Comments)
                .First();

            return issue.Comments.Select(m => new CommentResultDto
            {
                Id = m.Id,
                Content = m.Content,
                CreatedOn = m.CreatedOn,
                CreatedBy = m.CreatedBy,
                IssueId = m.IssueId
            });
        }

        public CommentResultDto Create(CommentDto comment)
        {
            Issue issue = _dbContext.Issues.Where(m => m.Id == comment.IssueId)
                .Where(m => m.ProjectId == comment.ProjectId)
                .First();
            Comment newComment = new Comment
            {
                Content = comment.Content,
                CreatedBy = _httpContext.User.GetUserId(),
                CreatedOn = DateTimeOffset.UtcNow,
                IssueId = issue.Id
            };
            _dbContext.Comments.Add(newComment);
            _dbContext.SaveChanges();
            return new CommentResultDto
            {
                Id = newComment.Id,
                Content = newComment.Content,
                CreatedOn = newComment.CreatedOn,
                CreatedBy = newComment.CreatedBy
            };
        }
    }
}
