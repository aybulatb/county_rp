using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(typeof(ApiForumWithModeratorsDtoOut), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWithModerators(int id)
        {
            var forumDtoOut = await _forumService.GetForumAsync(id);

            var forumModeratorFilterDtoIn = ForumIdConverter.ToForumModeratorFilterDtoIn(id);

            var moderatorsDtoOut = await _forumService.GetModeratorsByFilterAsync(forumModeratorFilterDtoIn);

            var groupIds = moderatorsDtoOut
                .Items
                .Where(moderator => moderator.EntityType == 1)
                .Select(moderator => moderator.EntityId);

            var userIds = moderatorsDtoOut
                .Items
                .Where(moderator => moderator.EntityType == 2)
                .Select(moderator => moderator.EntityId);

            var groups = await _siteService.GetGroupsByFilterAsync(
                new SiteGroupFilterDtoIn(
                    Count: null,
                    Page: null,
                    Ids: groupIds,
                    Name: null
                )
            );

            var users = await _siteService.GetUsersByFilterAsync(
                new SiteUserFilterDtoIn(
                    Count: null,
                    Page: null,
                    Ids: userIds,
                    Login: null,
                    LoginLike: null,
                    GroupIds: null,
                    PlayerIds: null,
                    StartRegistrationDate: null,
                    FinishRegistrationDate: null,
                    StartLastVisitDate: null,
                    FinishLastVisitDate: null
                )
            );

            var namedModerators = new List<ApiModeratorDtoOut>();

            foreach (var moderator in moderatorsDtoOut.Items)
            {
                var moderatorName = moderator.EntityType == 1
                    ? groups.Items.FirstOrDefault(group => group.Id == moderator.EntityId)?.Name
                    : users.Items.FirstOrDefault(user => user.Id == moderator.EntityId)?.Login;

                namedModerators.Add(
                    ForumModeratorDtoOutConverter.ToApi(
                        source: moderator,
                        name: moderatorName
                    )
                );
            }

            var apiForumWithModeratorsDtoOut = ForumForumDtoOutConverter.ToApiForumWithModeratorsDtoOut(
                source: forumDtoOut,
                moderators: namedModerators
            );

            return Ok(apiForumWithModeratorsDtoOut);
        }

        [HttpPut("{id}/Moderators")]
        public async Task<IActionResult> EditWithModerators(int id, [FromBody] ApiUpdatedForumWithModeratorsDtoIn apiUpdatedForumWithModeratorsDtoIn)
        {
            var forumModeratorFilterDtoIn = ForumIdConverter.ToForumModeratorFilterDtoIn(id);

            var moderatorsDtoOut = await _forumService.GetModeratorsByFilterAsync(forumModeratorFilterDtoIn);

            if (apiUpdatedForumWithModeratorsDtoIn.DeletedModeratorsIds.Any())
            {
                var existedModeratorsForDeleting = moderatorsDtoOut
                    .Items
                    .Where(moderator => apiUpdatedForumWithModeratorsDtoIn.DeletedModeratorsIds.Contains(moderator.Id));

                if (existedModeratorsForDeleting.Count() != apiUpdatedForumWithModeratorsDtoIn.DeletedModeratorsIds.Count())
                {
                    return BadRequest();
                }

                var groupModeratorsForDeleting = existedModeratorsForDeleting
                    .Where(moderator => moderator.EntityType == 1);

                if (groupModeratorsForDeleting.Any())
                {
                    return BadRequest();
                }
            }

            if (apiUpdatedForumWithModeratorsDtoIn.NewModerators.Any())
            {
                var groupNewModerators = apiUpdatedForumWithModeratorsDtoIn
                .NewModerators
                .Where(moderator => moderator.EntityType == ApiModeratorEntityTypeDto.Group);

                if (groupNewModerators.Any())
                {
                    return BadRequest();
                }

                var userNewModerators = apiUpdatedForumWithModeratorsDtoIn
                    .NewModerators
                    .Where(moderator => moderator.EntityType == ApiModeratorEntityTypeDto.User);

                var hasDuplicatedModerators = userNewModerators
                    .Any(newModerator =>
                        moderatorsDtoOut.Items.Any(
                            moderator =>
                                moderator.EntityId == newModerator.EntityId &&
                                moderator.EntityType == 2 && newModerator.EntityType == ApiModeratorEntityTypeDto.User
                    )
                );

                if (hasDuplicatedModerators)
                {
                    return BadRequest();
                }
            }

            if (apiUpdatedForumWithModeratorsDtoIn.UpdatedModerators.Any())
            {
                var allModeratorsExistForUpdating = moderatorsDtoOut
                    .Items
                    .All(moderator => apiUpdatedForumWithModeratorsDtoIn.UpdatedModerators.Any(updatedModerator => updatedModerator.Id == moderator.Id));

                if (allModeratorsExistForUpdating)
                {
                    return BadRequest();
                }

                var updatedModerators = moderatorsDtoOut
                    .Items
                    .Join(
                        apiUpdatedForumWithModeratorsDtoIn.UpdatedModerators,
                        moderator => moderator.Id,
                        updatedModerator => updatedModerator.Id,
                        (moderator, updatedModerator) =>
                            ForumModeratorDtoOutConverter.ToUpdatedForumModeratorDtoOut(
                                source: moderator,
                                updatedModerator: updatedModerator
                            )
                    );

                await _forumService.UpdateModeratorsAsync(updatedModerators);
            }

            if (apiUpdatedForumWithModeratorsDtoIn.DeletedModeratorsIds.Any())
            {
                var forumModeratorFilterDtoInForDeleting = ModeratorIdsConverter
                .ToForumModeratorFilterDtoIn(apiUpdatedForumWithModeratorsDtoIn.DeletedModeratorsIds);

                await _forumService.DeleteModeratorsByFilterAsync(forumModeratorFilterDtoInForDeleting);
            }

            if (apiUpdatedForumWithModeratorsDtoIn.NewModerators.Any())
            {
                var moderatorsDtoIn = apiUpdatedForumWithModeratorsDtoIn
                .NewModerators
                .Select(moderator =>
                    ApiModeratorDtoInConverter.ToService(
                        source: moderator,
                        forumId: id
                    )
                );

                await _forumService.CreateModeratorsAsync(moderatorsDtoIn);
            }

            if (apiUpdatedForumWithModeratorsDtoIn.UpdatedModerators.Any())
            {

            }

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

            var haveGroupModeratorsRealIds = groups
                .Items
                .All(group => groupModerators.Any(groupModerator => groupModerator.EntityId == group.Id));
            var equalGroupModeratorsCount = groupModerators.Count() == groups.AllCount;

            if (!haveGroupModeratorsRealIds || !equalGroupModeratorsCount)
            {
                return BadRequest();
            }

            var users = await _siteService.GetUsersByFilterAsync(
                new SiteUserFilterDtoIn(
                    Count: null,
                    Page: null,
                    Ids: userModerators.Select(userModerator => userModerator.EntityId),
                    Login: null,
                    LoginLike: null,
                    GroupIds: null,
                    PlayerIds: null,
                    StartRegistrationDate: null,
                    FinishRegistrationDate: null,
                    StartLastVisitDate: null,
                    FinishLastVisitDate: null
                )
            );

            var equalUserModeratorsCount = userModerators.Count() == users.AllCount;

            if (!equalGroupModeratorsCount)
            {
                return BadRequest();
            }

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
