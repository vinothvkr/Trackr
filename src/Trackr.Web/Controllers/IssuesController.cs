using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackr.Infrastructure.Dtos;
using Trackr.Infrastructure.Dtos.Issue;
using Trackr.Infrastructure.Models;
using Trackr.Infrastructure.Services;

namespace Trackr.Web.Controllers
{
    [Route("api/projects/{projectId}/issues")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }
        // GET: api/projects/{projectId}/Issues
        [HttpGet]
        public IActionResult Get(int projectId)
        {
            return Ok(_issueService.GetAll(projectId));
        }

        // GET: api/projects/2/Issues/5
        [HttpGet("{id}", Name = "GetIssue")]
        public IActionResult Get(int projectId, int id)
        {
            return Ok(_issueService.Get(id));
        }

        // POST: api/projects/{projectId}/Issues
        [HttpPost]
        public IActionResult Post([FromBody] IssueDto dto)
        {
            return Ok(new ResultDto
            {
                Id = _issueService.Create(dto)
            });
        }

        // PUT: api/projects/{projectId}/Issues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
