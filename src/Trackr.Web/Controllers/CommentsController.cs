using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackr.Infrastructure.Dtos.Comment;
using Trackr.Infrastructure.Services;

namespace Trackr.Web.Controllers
{
    [Route("api/projects/{projectId}/issues/{issueId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: api/Comments
        [HttpGet]
        public IActionResult Get(int projectId, int issueId)
        {
            return Ok(_commentService.GetAll(projectId, issueId));
        }

        // GET: api/Comments/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comments
        [HttpPost]
        public IActionResult Post(int projectId, int issueId, [FromBody] CommentDto comment)
        {
            comment.IssueId = issueId;
            comment.ProjectId = projectId;
            return Ok(_commentService.Create(comment));
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
