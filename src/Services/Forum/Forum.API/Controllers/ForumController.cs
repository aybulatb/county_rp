﻿using CountyRP.Services.Forum.API.Comparers;
using CountyRP.Services.Forum.API.Converters;
using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;
using CountyRP.Services.Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly ILogger<ForumController> _logger;
        private readonly IForumRepository _forumRepository;

        public ForumController(
            ILogger<ForumController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
        }

        /// <summary>
        /// Создать форум.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiForumDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ApiForumDtoIn apiForumDtoIn)
        {
            var validationResult = await ValidateForum(apiForumDtoIn);

            if (validationResult != null)
            {
                return validationResult;
            }

            var forumDtoIn = ApiForumDtoInConverter.ToRepository(apiForumDtoIn);

            var forumDtoOut = await _forumRepository.CreateForumAsync(forumDtoIn);

            return Created(
                string.Empty,
                ForumDtoOutConverter.ToApi(forumDtoOut)
            );
        }

        /// <summary>
        /// Получить все форумы.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiForumDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var forumsDtoOut = await _forumRepository.GetForumsAsync();

            return Ok(
                forumsDtoOut.Select(ForumDtoOutConverter.ToApi)
            );
        }

        /// <summary>
        /// Получить все форумы.
        /// </summary>
        [HttpGet("Hierarchical")]
        [ProducesResponseType(typeof(IEnumerable<ApiHierarchicalForumDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHierarchical()
        {
            var forumsDtoOut = await _forumRepository.GetHierarchicalForumsAsync();

            return Ok(
                forumsDtoOut
                    .Select(HierarchicalForumDtoOutConverter.ToApi)
            );
        }

        /// <summary>
        /// Получить данные форума по ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiForumDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var forumDtoOut = await _forumRepository.GetForumByIdAsync(id);

            if (forumDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ForumNotFoundById, id)
                );
            }

            return Ok(
                ForumDtoOutConverter.ToApi(forumDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список форумов.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResult<ApiForumDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiForumFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.CountItemPerPageMoreThan100);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiForumFilterDtoInConverter.ToRepository(filter);

            var filteredForums = await _forumRepository.GetForumsByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredForums)
            );
        }

        /// <summary>
        /// Изменить данные форума по ID.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] ApiForumDtoIn apiForumDtoIn)
        {
            var existedForum = await _forumRepository.GetForumByIdAsync(id);

            if (existedForum == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ForumNotFoundById, id)
                );
            }

            var validationResult = await ValidateForum(apiForumDtoIn, id);

            if (validationResult != null)
            {
                return validationResult;
            }

            var forumDtoOut = ApiForumDtoInConverter.ToDtoOut(
                source: apiForumDtoIn,
                id: id 
            );

            await _forumRepository.UpdateForumAsync(forumDtoOut);

            return NoContent();
        }

        [HttpPut("Ordered")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditOrdered([FromBody] IEnumerable<ApiUpdatedOrderedForumDtoIn> apiUpdatedOrderedForumsDtoIn)
        {
            var currentForums = await _forumRepository.GetForumsByFilterAsync(
                new ForumFilterDtoIn(
                    count: null,
                    page: null,
                    ids: null,
                    parentIds: null
                )
            );

            var updatedOrderedForumsDtoIn = apiUpdatedOrderedForumsDtoIn
                .Select(ApiUpdatedOrderedForumDtoInConverter.ToForumDtoOut);

            var result = ValidateForumsOrdering(currentForums.Items, updatedOrderedForumsDtoIn);

            if (!result)
            {
                return BadRequest();
            }

            await _forumRepository.UpdateForumsAsync(updatedOrderedForumsDtoIn);

            return NoContent();
        }

        /// <summary>
        /// Удалить форум по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedForum = await _forumRepository.GetForumByIdAsync(id);

            if (existedForum == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ForumNotFoundById, id)
                );
            }

            var forumParentId = existedForum.ParentId;

            await DeleteForumModeratorsTopicsPostsAndUpdateOrdering(id, forumParentId);

            return Ok();
        }

        [HttpPost("Validation")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Validate(ApiForumDtoIn apiForumDtoIn)
        {
            var validationResult = await ValidateForum(apiForumDtoIn);

            if (validationResult != null)
            {
                return validationResult;
            }

            return Ok();
        }

        private async Task<IActionResult> ValidateForum(ApiForumDtoIn apiForumDtoIn, int id = 0)
        {
            if (apiForumDtoIn.Name == null || apiForumDtoIn.Name.Length < 1 || apiForumDtoIn.Name.Length > 96)
            {
                return BadRequest(ConstantMessages.ForumInvalidNameLength);
            }

            var sourceForums = await _forumRepository.GetForumsByFilterAsync(
                new ForumFilterDtoIn(
                    count: null,
                    page: null,
                    ids: null,
                    parentIds: null
                )
            );

            var forumDtoOut = ApiForumDtoInConverter.ToDtoOut(
                source: apiForumDtoIn,
                id: id
            );

            var result = ValidateForumsOrdering(sourceForums.Items, new[] { forumDtoOut });

            if (!result)
            {
                return BadRequest();
            }

            return null;
        }

        private bool ValidateForumsOrdering(IEnumerable<ForumDtoOut> sourceForums, IEnumerable<ForumDtoOut> newForums)
        {
            var updatedForums = sourceForums
                .GroupJoin(
                    newForums.DefaultIfEmpty(),
                    sourceForum => sourceForum.Id,
                    updatedForum => updatedForum.Id,
                    (sourceForum, updatedForum) => new
                    {
                        SourceForum = sourceForum,
                        UpdatedForum = updatedForum
                    }
                )
                .SelectMany(
                    x => x.UpdatedForum.DefaultIfEmpty(),
                    (sourceForum, updatedForum) => new ForumDtoOut(
                        id: sourceForum.SourceForum.Id,
                        name: sourceForum.SourceForum.Name,
                        parentId: updatedForum == null ? sourceForum.SourceForum.ParentId : updatedForum.ParentId,
                        order: updatedForum == null ? sourceForum.SourceForum.Order : updatedForum.Order
                    )
                )
                .Union(newForums, new ForumDtoOutComparer());

            var updatedForumGroupsByParentIdAndOrder = updatedForums
                .GroupBy(forum => forum.ParentId)
                .Select(forumGroup => forumGroup.GroupBy(forum => forum.Order));

            var allAreMoreOrEqualThanZero = updatedForums.All(forum => forum.Order >= 0);
            var doNotHaveDuplicates = updatedForumGroupsByParentIdAndOrder
                .Select(forumGroup => forumGroup.All(forum => forum.Count() == 1))
                .All(result => result == true);
            var doNotHavePasses = updatedForumGroupsByParentIdAndOrder
                .All(forumGroup => forumGroup.Count() == forumGroup.Max(forum => forum.Key) + 1);

            if (allAreMoreOrEqualThanZero && doNotHaveDuplicates && doNotHavePasses)
            {
                return true;
            }

            return false;
        }

        private async Task DeleteForumModeratorsTopicsPostsAndUpdateOrdering(int id, int forumParentId)
        {
            var topicFilterDtoIn = ForumIdConverter.ToTopicFilterDtoIn(id);
            var moderatorFilterDtoIn = ForumIdConverter.ToModeratorFilterDtoIn(id);
            var forumFilterDtoIn = ForumIdConverter.ToForumFilterDtoIn(id);

            var topicsForDeleting = await _forumRepository.GetTopicByFilterAsync(topicFilterDtoIn);
            var topicIdsForDeleting = topicsForDeleting
                .Items
                .Select(topic => topic.Id);

            await _forumRepository.DeleteForumAsync(id);
            await _forumRepository.DeleteModeratorsByFilterAsync(moderatorFilterDtoIn);
            await _forumRepository.DeleteTopicsOnForumByIdAsync(id);
            await _forumRepository.DeletePostsOnTopicByIdsAsync(topicIdsForDeleting);

            await UpdateOrdering(forumParentId);

            var childForums = await _forumRepository.GetForumsByFilterAsync(forumFilterDtoIn);

            foreach (var forum in childForums.Items)
            {
                await DeleteForumModeratorsTopicsPostsAndUpdateOrdering(forum.Id, forum.ParentId);
            }
        }

        private async Task UpdateOrdering(int forumParentId)
        {
            var forumsWithParentId = await _forumRepository.GetForumsByFilterAsync(
                new ForumFilterDtoIn(
                    count: null,
                    page: null,
                    ids: null,
                    parentIds: new[] { forumParentId }
                )
            );

            var orderedForums = forumsWithParentId
                .Items
                .OrderBy(forum => forum.Order);

            var updatedOrderedForums = new List<ForumDtoOut>();

            for (var i = 0; i < orderedForums.Count(); i++)
            {
                var forum = orderedForums.ElementAt(i);

                updatedOrderedForums.Add(
                    new ForumDtoOut(
                        id: forum.Id,
                        name: forum.Name,
                        parentId: forum.ParentId,
                        order: i
                    )
                );
            }

            await _forumRepository.UpdateForumsAsync(updatedOrderedForums);
        }
    }
}
