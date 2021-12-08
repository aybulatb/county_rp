using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
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
        private readonly ISiteService _siteService;

        public ForumController(
            ILogger<ForumController> logger,
            IForumService forumService,
            ISiteService siteService
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
            _siteService = siteService ?? throw new ArgumentNullException(nameof(siteService));
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

        [HttpPut("Ordered")]
        public async Task<IActionResult> EditOrdered(IEnumerable<ApiUpdatedOrderedForumDtoIn> apiUpdatedOrderedForumDtoIn)
        {
            var updatedOrderedForumDtoIn = apiUpdatedOrderedForumDtoIn
                .Select(ApiUpdatedOrderedForumDtoInConverter.ToService);

            await _forumService.UpdateOrderedForumsAsync(updatedOrderedForumDtoIn);

            return NoContent();
        }

        [HttpGet("{id}/Moderators")]
        public async Task<IActionResult> GetWithModerators(int id)
        {
            var forumDtoOut = await _forumService.GetForumAsync(id);

            var forumModeratorFilterDtoIn = ForumIdConverter.ToForumModeratorFilterDtoIn(id);

            var moderatorsDtoOut = await _forumService.GetModeratorsByFilterAsync(forumModeratorFilterDtoIn);

            var apiForumWithModeratorsDtoOut = ForumForumDtoOutConverter.ToApiForumWithModeratorsDtoOut(
                source: forumDtoOut,
                moderators: moderatorsDtoOut.Items
            );

            return Ok(apiForumWithModeratorsDtoOut);
        }

        [HttpPut("{id}/Moderators")]
        public async Task<IActionResult> EditWithModerators(int id)
        {
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApiForumWithModeratorsDtoIn apiForumWithModeratorsDtoIn)
        {
            var groupModerators = apiForumWithModeratorsDtoIn
                .Moderators
                .Where(moderator => moderator.EntityType == ApiModeratorEntityTypeDto.Group);
            var userModerators = apiForumWithModeratorsDtoIn
                .Moderators
                .Where(moderator => moderator.EntityType == ApiModeratorEntityTypeDto.User);

            var groups = await _siteService.GetGroupsByFilterAsync(
                new SiteGroupFilterDtoIn(
                    Count: null,
                    Page: null,
                    Ids: null,
                    Name: null
                )
            );

            //groups
            //    .Items
            //    .All(group => groupModerators.Contains(group.Id));

            var forumDtoIn = ApiForumWithModeratorsDtoInConverter.ToService(apiForumWithModeratorsDtoIn);

            var forumDtoOut = await _forumService.CreateForumAsync(forumDtoIn);

            var moderatorsDtoIn = apiForumWithModeratorsDtoIn
                .Moderators
                .Select(moderator =>
                    ApiModeratorDtoInConverter.ToService(
                        source: moderator,
                        forumId: forumDtoOut.Id
                    )
                );
            
            await _forumService.CreateModeratorsAsync(moderatorsDtoIn);

            return Created(string.Empty, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _forumService.DeleteForumAsync(id);

            return Ok();
        }
    }
}
