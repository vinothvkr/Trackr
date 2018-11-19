using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackr.Infrastructure.Models;
using Trackr.Infrastructure.Services;

namespace Trackr.Web.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService,
            IIssueService issueService)
        {
            _projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_projectService.GetAll());
        }

        // GET: api/Projects/5
        [HttpGet("{id}", Name = "GetProject")]
        public JsonResult Get(int id)
        {
            return Json(_projectService.Get(id));
        }

        // POST: api/Projects
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
