using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly ILogger<ForumController> _logger;
        private readonly IForumService _forumService;

        public ForumController(
            ILogger<ForumController> logger,
            IForumService forumService
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        }

        [HttpGet("Hierarchical")]
        public async Task<IActionResult> GetHierarchical()
        {
            var hierarchicalForums = await _forumService.GetHierarchicalForumsAsync();

            return Ok(
                hierarchicalForums
                    .Select(ForumHierarchicalForumDtoOutConverter.ToApi)
            );
        }

        [HttpPut("Hierarchical")]
        public async Task<IActionResult> EditHierarchical(IEnumerable<ApiUpdatedOrderedForumDtoIn> apiUpdatedOrderedForumDtoIn)
        {
            return NoContent();
        }
    }
}
