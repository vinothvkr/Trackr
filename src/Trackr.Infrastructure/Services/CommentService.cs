using Microsoft.AspNetCore.Http;
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
        public CommentResultDto Create(CommentDto comment)
        {
            Issue issue = _dbContext.Issues.Where(m => m.Id == comment.IssueId).First();
            Comment newComment = new Comment
            {
                Content = comment.Content,
                CreatedBy = _httpContext.User.GetUserId(),
                CreatedOnUTC = DateTime.UtcNow,
                IssueId = issue.Id
            };
            _dbContext.Comments.Add(newComment);
            _dbContext.SaveChanges();
            return new CommentResultDto
            {
                Id = newComment.Id,
                Content = newComment.Content,
                CreatedOnUTC = newComment.CreatedOnUTC,
                CreatedBy = newComment.CreatedBy
            };
        }
    }
}
