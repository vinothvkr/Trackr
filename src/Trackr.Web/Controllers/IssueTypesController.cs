using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackr.Infrastructure.Services;

namespace Trackr.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTypesController : BaseController
    {
        private readonly IIssueTypeService _issueTypeService;

        public IssueTypesController(IIssueTypeService issueTypeService)
        {
            _issueTypeService = issueTypeService;
        }
        // GET: api/IssueTypes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_issueTypeService.GetAll());
        }
    }
}
